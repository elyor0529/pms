namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public  class LeaseFile : BaseEntity
    {
        public int? LeaseId { get; set; }
        public string Path { get; set; }

        [ForeignKey("LeaseId")]
        public virtual Lease Lease { get; set; }
    }
}
