using PMS.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using PagedList;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using PMS.Api.Helpers;
using System.Net.Mail;
using AutoMapper;

namespace PMS.Api.Controllers
{
    [Authorize]
    public class TenantController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private const int PAGE_SIZE = 50;

        [HttpGet]
        [ActionName("list")]
        public IHttpActionResult GetList(int page = 1, string search = "")
        {
            var query = _db.Tenants
                .Include(i => i.Lease)
                .Include(i => i.Lease.LeaseType)
                .Include(i => i.Lease.LeaseFiles)
                .Include(i => i.Lease.PaymentFrequency)
                .Include(i => i.Lease.PaymentType)
                .Include(i => i.PrincipalTenants)
                .Include(i => i.PropertyTenantMaps)
                .Include(i => i.PropertyTenantMaps.Select(s => s.Property))
                .Where(w => w.PrincipalTenantId == null && w.IsActive == true);
            var pager = String.IsNullOrWhiteSpace(search)
               ? query.OrderByDescending(o => o.Id)
                      .ToPagedList(page, PAGE_SIZE)
               : query.Where(w => w.FirstName.Contains(search) || w.LastName.Contains(search) || w.CellPhone.Contains(search) || w.Email.Contains(search))
                      .OrderByDescending(o => o.Id).ToPagedList(page, PAGE_SIZE);
            var model = new PagerListViewModel<TenantItemViewModel>
            {
                Items = pager.Select(s =>
                                {
                                    var property = s.PropertyTenantMaps.FirstOrDefault()?.Property ?? new Property();
                                    var tenant = new TenantItemViewModel
                                    {
                                        Id = s.Id,
                                        Tenant = s.FirstName + " " + s.LastName,
                                        PrimaryContacts = new
                                        {
                                            cell = s.CellPhone,
                                            home = s.HomePhone ?? "",
                                            mail = s.Email
                                        },
                                        LeaseDetails = new
                                        {
                                            agreement = s.Lease.LeaseTypeId == 1 ? "Moved" : "Move In",
                                            date = s.Lease.EndDate?.ToShortDateString(),
                                            expire = (s.Lease.LeaseTypeId == 1 && s.Lease.EndDate != null) ? "Expire in " + (int)s.Lease.EndDate?.Subtract(DateTime.Now).TotalDays : s.Lease.LeaseType.Name
                                        },
                                        Property = property.Name,
                                        Unit = property.Unit,
                                        Rent = s.Lease.Rent,
                                        HasLeaseEnd = s.Lease.EndDate.HasValue,
                                        SubTenants = s.PrincipalTenants.Select(p => p.FirstName + " " + p.LastName).ToArray(),
                                        Attachments = s.Lease.LeaseFiles.Select(p => p.Path).ToArray(),
                                        ExpiringInDays = (s.Lease.LeaseTypeId == 1 && s.Lease.MoveInDate != null) ? (int?)s.Lease.MoveInDate?.Subtract(DateTime.Now).TotalDays : null
                                    };

                                    return tenant;
                                }),
                Pager = pager.GetMetaData()
            };

            return Ok(model);
        }

        [HttpGet]
        [ActionName("details")]
        public async Task<IHttpActionResult> GetDetails(int? id)
        {
            if (id == null)
                return BadRequest();

            var tenant = await _db.Tenants.Include(a => a.PropertyTenantMaps).Include(a => a.PropertyTenantMaps.Select(s => s.Property)).Include(a => a.PrincipalTenants).Include(a => a.Lease).Include(a => a.Lease.LeaseFiles).FirstOrDefaultAsync(f => f.Id == id);

            if (tenant == null)
                return NotFound();

            var model = new TenantFormViewModel();

            model.Property = tenant.PropertyTenantMaps.FirstOrDefault(f => f.TenantId == id)?.Property;
            model.Tenants.Add(tenant);
            model.Tenants.AddRange(tenant.PrincipalTenants);
            model.Lease = tenant.Lease;
            model.Files = tenant.Lease.LeaseFiles.ToList();

            return Ok(model);
        }

        [HttpPost]
        [ActionName("add")]
        public async Task<IHttpActionResult> Post(TenantFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lease = model.Lease;

            foreach (var file in model.Files)
            {
                lease.LeaseFiles.Add(new LeaseFile
                {
                    Path = file.Path
                });
            }
            _db.Leases.Add(lease);

            await _db.SaveChangesAsync();

            var tenant = model.Tenants[0];

            tenant.LeaseId = lease.Id;
            tenant.PropertyTenantMaps.Add(new PropertyTenantMap
            {
                PropertyId = model.Property.Id
            });

            for (var i = 1; i < model.Tenants.Count; i++)
            {
                var principalTenant = model.Tenants[i];

                principalTenant.LeaseId = lease.Id;
                principalTenant.PropertyTenantMaps.Add(new PropertyTenantMap
                {
                    PropertyId = model.Property.Id
                });

                tenant.PrincipalTenants.Add(principalTenant);
            }

            _db.Tenants.Add(tenant);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [ActionName("edit")]
        public async Task<IHttpActionResult> Put(TenantFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lease = await _db.Leases.Include(i => i.LeaseFiles).FirstOrDefaultAsync(f => f.Id == model.Lease.Id);

            if (lease == null)
                return NotFound();

            lease.DelinquentAfter = model.Lease.DelinquentAfter;
            lease.Deposit = model.Lease.Deposit;
            lease.EndDate = model.Lease.EndDate;
            lease.LeaseTypeId = model.Lease.LeaseTypeId;
            lease.MoveInDate = model.Lease.MoveInDate;
            lease.Notes = model.Lease.Notes;
            lease.PaymentFrequencyId = model.Lease.PaymentFrequencyId;
            lease.PaymentTypeId = model.Lease.PaymentTypeId;
            lease.PetsFlag = model.Lease.PetsFlag;
            lease.Rent = model.Lease.Rent;
            lease.SmokingFlag = model.Lease.SmokingFlag;
            lease.StartDate = model.Lease.StartDate;

            foreach (var file in model.Files.Where(w => w.Id == 0))
            {
                lease.LeaseFiles.Add(new LeaseFile
                {
                    Path = file.Path
                });
            }

            _db.Leases.Attach(lease);
            _db.Entry(lease).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            var id = model.Tenants[0].Id;
            var tenant = await _db.Tenants.Include(i => i.PropertyTenantMaps).Include(i => i.PrincipalTenants).FirstOrDefaultAsync(f => f.Id == id);

            if (tenant == null)
                return NotFound();

            if (tenant.PropertyTenantMaps.Any(a => a.PropertyId != model.Property.Id))
            {
                tenant.PropertyTenantMaps.Remove(tenant.PropertyTenantMaps.FirstOrDefault(f => f.TenantId == model.Tenants[0].Id));
                tenant.PropertyTenantMaps.Add(new PropertyTenantMap
                {
                    PropertyId = model.Property.Id
                });
            }
            tenant.Company = model.Tenants[0].Company;
            tenant.FirstName = model.Tenants[0].FirstName;
            tenant.LastName = model.Tenants[0].LastName;
            tenant.CellPhone = model.Tenants[0].CellPhone;
            tenant.Email = model.Tenants[0].Email;
            tenant.HomePhone = model.Tenants[0].HomePhone;
            tenant.DOB = model.Tenants[0].DOB;

            for (var i = 1; i < model.Tenants.Count; i++)
            {
                var principalTenant = model.Tenants[i];

                if (principalTenant.Id == 0)
                {
                    principalTenant.LeaseId = lease.Id;
                    principalTenant.PropertyTenantMaps.Add(new PropertyTenantMap
                    {
                        PropertyId = model.Property.Id
                    });
                    principalTenant.PrincipalTenantId = id;

                    tenant.PrincipalTenants.Add(principalTenant);
                }
                else
                {
                    principalTenant = tenant.PrincipalTenants.FirstOrDefault(f => f.Id == principalTenant.Id);

                    principalTenant.Company = model.Tenants[i].Company;
                    principalTenant.FirstName = model.Tenants[i].FirstName;
                    principalTenant.LastName = model.Tenants[i].LastName;
                    principalTenant.CellPhone = model.Tenants[i].CellPhone;
                    principalTenant.Email = model.Tenants[i].Email;
                    principalTenant.HomePhone = model.Tenants[i].HomePhone;
                    principalTenant.DOB = model.Tenants[i].DOB;
                }
            }

            _db.Tenants.Attach(tenant);
            _db.Entry(tenant).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [ActionName("remove")]
        public async Task<IHttpActionResult> Delete(int? id)
        {

            if (id == null)
                return BadRequest();

            var model = await _db.Tenants.FindAsync(id);

            if (model == null)
                return NotFound();

            model.IsActive = false;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [ActionName("send-email")]
        public async Task<IHttpActionResult> SendEmail(TenantEmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = new IdentityMessage
            {
                Body = model.Body,
                Destination = model.To,
                Subject = model.Subject
            };

            await SendGridHelper.SendAsync(message, new MailAddress(model.From));

            return Ok();
        }

        [HttpDelete]
        [ActionName("remove-file")]
        public async Task<IHttpActionResult> DeleteFile(int? id)
        {
            if (id == null)
                return BadRequest();

            var file = await _db.LeaseFiles.Include(i => i.Lease).FirstOrDefaultAsync(f => f.Id == id);

            if (file == null)
                return NotFound();

            file.Lease.LeaseFiles.Remove(file);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [ActionName("remove-tenant")]
        public async Task<IHttpActionResult> DeleteTenant(int? id)
        {
            if (id == null)
                return BadRequest();

            var tenant = await _db.Tenants.Include(i => i.PrincipalTenant).Include(i => i.PrincipalTenant.PrincipalTenants).FirstOrDefaultAsync(f => f.Id == id);

            if (tenant == null)
                return NotFound();

            var principalTenantId = tenant.PrincipalTenantId;

            if (principalTenantId == null)
                return InternalServerError();

            tenant.PrincipalTenant.PrincipalTenants.Remove(tenant);

            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
