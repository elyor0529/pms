namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class SaasEcomUser : BaseEntity
    {
        public SaasEcomUser()
        {
            CreditCards = new HashSet<CreditCard>();
            Invoices = new HashSet<Invoice>();
            Subscriptions = new HashSet<Subscription>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string StripeCustomerId { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressCountry { get; set; }
        public bool Delinquent { get; set; }
        public decimal LifetimeValue { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
