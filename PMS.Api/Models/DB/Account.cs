

namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class Account : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }
    }
}