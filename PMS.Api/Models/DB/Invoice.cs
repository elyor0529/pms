namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            LineItems = new HashSet<LineItem>();
        }

        public string StripeId { get; set; }
        public string StripeCustomerId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public int? Subtotal { get; set; }
        public int? Total { get; set; }
        public bool? Attempted { get; set; }
        public bool? Closed { get; set; }
        public bool? Paid { get; set; }
        public int? AttemptCount { get; set; }
        public int? AmountDue { get; set; }
        public int? StartingBalance { get; set; }
        public int? EndingBalance { get; set; }
        public DateTime? NextPaymentAttempt { get; set; }
        public int? ApplicationFee { get; set; }
        public int? Tax { get; set; }
        public decimal? TaxPercent { get; set; }
        public string Currency { get; set; }
        public string BillingAddress_Name { get; set; }
        public string BillingAddress_AddressLine1 { get; set; }
        public string BillingAddress_AddressLine2 { get; set; }
        public string BillingAddress_City { get; set; }
        public string BillingAddress_State { get; set; }
        public string BillingAddress_ZipCode { get; set; }
        public string BillingAddress_Country { get; set; }
        public string BillingAddress_Vat { get; set; }
        public string Description { get; set; }
        public string StatementDescriptor { get; set; }
        public string ReceiptNumber { get; set; }
        public bool Forgiven { get; set; } 

        public int? SaasEcomUserId { get; set; }

        [ForeignKey("SaasEcomUserId")]
        public virtual SaasEcomUser SaasEcomUser { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
