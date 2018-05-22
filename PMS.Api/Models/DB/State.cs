namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class State : BaseEntity
    {
        public int? CountryId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string ForeignName { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
