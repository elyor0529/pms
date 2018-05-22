namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Property : BaseEntity
    {
        public Property()
        {
            Companies = new HashSet<Company>();
            PropertyTenantMaps = new HashSet<PropertyTenantMap>();
            Properties = new HashSet<Property>();
        }

        public int? PropertyTypeId { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
        public int? RecordStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateBuild { get; set; }
        public decimal? Area { get; set; }
        public int? RentalStatusId { get; set; }
        public string Notes { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public double? Bedrooms { get; set; }
        public double? Baths { get; set; }
        public int? Units { get; set; }
        public decimal? Rent { get; set; }
        public decimal? Deposit { get; set; }
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<PropertyTenantMap> PropertyTenantMaps { get; set; }

        [ForeignKey("PropertyTypeId")]
        public virtual PropertyType PropertyType { get; set; }
        public virtual ICollection<Property> Properties { get; set; }

        [ForeignKey("ParentId")]
        public virtual Property Parent { get; set; }

        [ForeignKey("RecordStatusId")]
        public virtual RecordStatus RecordStatus { get; set; }

        [ForeignKey("RentalStatusId")]
        public virtual RentalStatus RentalStatus { get; set; }

        [ForeignKey("CountryId")]
        public virtual RentalStatus Country { get; set; }

    }
}
