namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class TenantAddressMap : BaseEntity
    {
        public int? TenantId { get; set; }
        public int? AddressId { get; set; }
        public int? AddressTypeId { get; set; }
        public string Note { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [ForeignKey("AddressTypeId")]
        public virtual AddressType AddressType { get; set; }
         
        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }
    }
}
