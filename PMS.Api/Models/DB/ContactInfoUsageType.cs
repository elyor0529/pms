namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ContactInfoUsageType : BaseEntity
    {
        public ContactInfoUsageType()
        {
             TenantContactInfoMaps = new HashSet<TenantContactInfoMap>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<TenantContactInfoMap> TenantContactInfoMaps { get; set; }
    }
}
