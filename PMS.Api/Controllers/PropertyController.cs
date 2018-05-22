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

namespace PMS.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/property")]
    public class PropertyController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("list")]
        public async Task<IHttpActionResult> Get()
        {
            var model = await _db.Properties.ToListAsync();

            return Ok(model);
        }
    }
}