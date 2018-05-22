namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class LineItem : BaseEntity
    {
        public string StripeLineItemId { get; set; }
        public string Type { get; set; }
        public int? Amount { get; set; }
        public string Currency { get; set; }
        public bool Proration { get; set; }
        public DateTime? Period_Start { get; set; }
        public DateTime? Period_End { get; set; }
        public int? Quantity { get; set; }
        public string Plan_StripePlanId { get; set; }
        public string Plan_Interval { get; set; }
        public string Plan_Name { get; set; }
        public DateTime? Plan_Created { get; set; }
        public int? Plan_AmountInCents { get; set; }
        public string Plan_Currency { get; set; }
        public int Plan_IntervalCount { get; set; }
        public int? Plan_TrialPeriodDays { get; set; }
        public string Plan_StatementDescriptor { get; set; }
        public int? InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
