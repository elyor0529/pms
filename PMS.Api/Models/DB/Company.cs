namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Company : BaseEntity
    {
        public int? PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }
}
