namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class LeaseType : BaseEntity
    {
        public LeaseType()
        {
            Leases = new HashSet<Lease>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
    }
}
