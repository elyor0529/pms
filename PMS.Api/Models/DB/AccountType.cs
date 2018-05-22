namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AccountType : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; } 
    }
}
