namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class PaymentFrequency : BaseEntity
    {
        public PaymentFrequency()
        {
            Leases = new HashSet<Lease>();
        }

        public string Name { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
    }
}
