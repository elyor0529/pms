namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PropertySubType : BaseEntity
    {
        public int? TypeId { get; set; }
        public string Code { get; set; }
        public string Desc { get; set; } 

        [ForeignKey("TypeId")]
        public virtual PropertyType Type { get; set; }
    }
}
