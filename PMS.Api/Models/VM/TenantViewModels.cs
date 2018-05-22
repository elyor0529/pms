using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Api.Models
{
    public class TenantListViewModel
    {
        public IEnumerable<TenantItemViewModel> Items { get; set; }

        public IPagedList Pager { get; set; }

    }

    public class TenantItemViewModel
    {
        public int Id { get; set; }

        public string Tenant { get; set; }

        public string[] SubTenants { get; set; }

        public string Property{ get; set; }

        public string Unit { get; set; }

        public object LeaseDetails { get; set; }

        public object PrimaryContacts { get; set; }

        public int? ExpiringInDays { get; set; }

        public double? Rent { get; set; }

        public string[] Attachments { get; set; }
        public bool? HasLeaseEnd { get; internal set; }
    }

    public class TenantFormViewModel
    {

        public Property Property { get; set; }

        public List<Tenant> Tenants { get; set; }

        public Lease Lease { get; set; }

        public List<LeaseFile> Files { get; set; }

        public TenantFormViewModel()
        {
            Tenants = new List<Tenant>();
            Files = new List<LeaseFile>();
        }

    }

    public class TenantEmailViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        [EmailAddress]
        public string To { get; set; }

        public string Body { get; set; }
    }
}
