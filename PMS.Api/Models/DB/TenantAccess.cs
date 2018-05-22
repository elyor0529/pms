namespace PMS.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class TenantAccess : BaseEntity
    {
        public string AccessLevel { get; set; }
    }
}
