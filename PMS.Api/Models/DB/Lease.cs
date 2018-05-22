namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Lease : BaseEntity
    {
        public Lease()
        {
            LeaseFiles = new HashSet<LeaseFile>();
            Tenants = new HashSet<Tenant>();
        }

        public int? LeaseTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Deposit { get; set; }
        public int? DelinquentAfter { get; set; }
        public DateTime? MoveInDate { get; set; }
        public double? Rent { get; set; }
        public int? PaymentFrequencyId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? QuickPayId { get; set; }
        public string Notes { get; set; }
        public bool? PetsFlag { get; set; }
        public bool? SmokingFlag { get; set; }
          
        [ForeignKey("LeaseTypeId")]
        public virtual LeaseType LeaseType { get; set; }

        [ForeignKey("PaymentFrequencyId")]
        public virtual PaymentFrequency PaymentFrequency { get; set; }

        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<LeaseFile> LeaseFiles { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
