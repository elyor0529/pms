namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PropertyTenantMap : BaseEntity
    {
        public int? PropertyId { get; set; }
        public int? TenantId { get; set; }
        public bool IsProspect { get; set; }
        public bool IsOwner { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }
    }
}
