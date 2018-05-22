namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class SubscriptionPlanProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int? SubscriptionPlanId { get; set; }

        [ForeignKey("SubscriptionPlanId")]
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
