namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Country : BaseEntity
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            States = new HashSet<State>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
