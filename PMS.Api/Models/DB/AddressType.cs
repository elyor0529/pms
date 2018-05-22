namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public  class AddressType : BaseEntity
    {
        public AddressType()
        {
            TenantAddressMaps = new HashSet<TenantAddressMap>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<TenantAddressMap> TenantAddressMaps { get; set; }
    }
}
