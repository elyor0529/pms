
namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ContactInfoType : BaseEntity
    {
        public ContactInfoType()
        {
            ContactInfos = new HashSet<ContactInfo>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
