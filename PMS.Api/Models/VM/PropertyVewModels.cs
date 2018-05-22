using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Api.Models.VM
{
    public class PropertyItemVewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }           

    }

    public class TenantListViewModel
    {
        public IEnumerable<PropertyItemVewModel> Items { get; set; }
            
    }

}