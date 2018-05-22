namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PropertyType : BaseEntity
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
