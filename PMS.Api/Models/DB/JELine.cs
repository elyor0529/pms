namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class JELine : BaseEntity
    {
        public int? AccountId { get; set; }
        public int? TenantId { get; set; }
        public int? FinancialAccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public int? TransactionId { get; set; }
        public int? SourceId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("FinancialAccountId")]
        public virtual FinacialAccount FinancialAccount { get; set; }
    }
}
