namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Tenant : BaseEntity
    {
        public Tenant()
        {
            PropertyTenantMaps = new HashSet<PropertyTenantMap>();
            TenantAddressMaps = new HashSet<TenantAddressMap>();
            TenantContactInfoMaps = new HashSet<TenantContactInfoMap>();
            PrincipalTenants = new HashSet<Tenant>();
        }

        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInit { get; set; }
        public string IdNum { get; set; }
        public string IdState { get; set; }
        public string SS { get; set; }
        public int? PrincipalTenantId { get; set; }
        public int? PrincipalRelationTypeId { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        public string Notes { get; set; }
        public decimal? Income { get; set; }
        public int? LeaseId { get; set; }
        public bool? HasOnlineAccess { get; set; }
        public bool? AllowOnlineMessages { get; set; }
        public bool? HasForumAccess { get; set; }

        [ForeignKey("LeaseId")]
        public virtual Lease Lease { get; set; }

        [ForeignKey("PrincipalRelationTypeId")]
        public virtual PrincipalRelationType PrincipalRelationType { get; set; }

        [ForeignKey("PrincipalTenantId")]
        public virtual Tenant PrincipalTenant { get; set; }

        public virtual ICollection<Tenant> PrincipalTenants { get; set; }
        public virtual ICollection<PropertyTenantMap> PropertyTenantMaps { get; set; }
        public virtual ICollection<TenantAddressMap> TenantAddressMaps { get; set; }
        public virtual ICollection<TenantContactInfoMap> TenantContactInfoMaps { get; set; }
    }
}
