namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Address : BaseEntity
    {
        public Address()
        {
            TenantAddressMaps = new HashSet<TenantAddressMap>();
        }

        public string Unit { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public virtual ICollection<TenantAddressMap> TenantAddressMaps { get; set; }
    }
}
