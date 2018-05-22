namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Subscription : BaseEntity
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime? TrialStart { get; set; }
        public DateTime? TrialEnd { get; set; }
        public int? SubscriptionPlanId { get; set; }
        public int? SaasEcomUserId { get; set; }
        public string StripeId { get; set; }
        public string Status { get; set; }
        public decimal TaxPercent { get; set; }
        public string ReasonToCancel { get; set; }

        [ForeignKey("SaasEcomUserId")]
        public virtual SaasEcomUser SaasEcomUser { get; set; }

        [ForeignKey("SubscriptionPlanId")]
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
