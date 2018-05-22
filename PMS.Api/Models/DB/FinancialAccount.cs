namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class FinacialAccount : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }  
        public string Description { get; set; }
        public string Bank { get; set; }
        public string Routing { get; set; }
        public string AccountNum { get; set; }
        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }
    }
}
