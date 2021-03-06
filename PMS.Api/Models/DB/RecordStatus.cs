namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class RecordStatus : BaseEntity
    {
        public RecordStatus()
        {
            Properties = new HashSet<Property>();
        }

        public string Description { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
