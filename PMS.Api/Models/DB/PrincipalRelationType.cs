namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class PrincipalRelationType : BaseEntity
    {
        public PrincipalRelationType()
        {
            this.Tenants = new HashSet<Tenant>();
        }

        public string Description { get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
