namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ContactInfo : BaseEntity
    {
        public ContactInfo()
        {
            TenantContactInfoMaps = new HashSet<TenantContactInfoMap>();
        }

        public int? ContactInfoTypeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("ContactInfoTypeId")]
        public virtual ContactInfoType ContactInfoType { get; set; }
        public virtual ICollection<TenantContactInfoMap> TenantContactInfoMaps { get; set; }
    }
}
