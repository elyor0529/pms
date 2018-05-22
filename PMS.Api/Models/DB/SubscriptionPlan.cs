namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class SubscriptionPlan : BaseEntity
    {
        public SubscriptionPlan()
        {
            SubscriptionPlanProperties = new HashSet<SubscriptionPlanProperty>();
            Subscriptions = new HashSet<Subscription>();
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int Interval { get; set; }
        public int TrialPeriodInDays { get; set; }
        public bool Disabled { get; set; }

        public virtual ICollection<SubscriptionPlanProperty> SubscriptionPlanProperties { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
