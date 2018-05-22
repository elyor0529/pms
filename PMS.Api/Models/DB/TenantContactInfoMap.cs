namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class TenantContactInfoMap:BaseEntity
    {
        public int? TenantId { get; set; }
        public int? ContactInfoId { get; set; }
        public int? ContactInfoUsageTypeId { get; set; }
        public string Note { get; set; }

        [ForeignKey("ContactInfoId")]
        public virtual ContactInfo ContactInfo { get; set; }

        [ForeignKey("ContactInfoUsageTypeId")]
        public virtual ContactInfoUsageType ContactInfoUsageType { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }
    }
}
