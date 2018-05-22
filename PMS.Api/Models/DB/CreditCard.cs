namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CreditCard : BaseEntity
    {
        public string StripeId { get; set; }
        public string Name { get; set; }
        public string Last4 { get; set; }
        public string Type { get; set; }
        public string Fingerprint { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string Cvc { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CardCountry { get; set; }
        public int? SaasEcomUserId { get; set; }

        [ForeignKey("SaasEcomUserId")]
        public virtual SaasEcomUser SaasEcomUser { get; set; }
    }
}
