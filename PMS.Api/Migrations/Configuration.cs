using PMS.Api.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PMS.Api.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.PaymentTypes.AddOrUpdate(a => a.Id, new PaymentType[]
            {
                new PaymentType { Id=1,Name="Check" },
                new PaymentType { Id=2,Name="Cash" }
            });

            context.PaymentFrequencies.AddOrUpdate(a => a.Id, new PaymentFrequency[]
            {
                new PaymentFrequency {Id=1, Name="Once" },
                new PaymentFrequency {Id=2,Name="Daily" },
                new PaymentFrequency {Id=3,Name="Weekly" },
                new PaymentFrequency {Id=4,Name="Bi-Weekly" },
                new PaymentFrequency {Id=5,Name="Monthly" },
                new PaymentFrequency {Id=6,Name="Quartally" },
                new PaymentFrequency {Id=7,Name="Semi-Annually" },
                new PaymentFrequency {Id=8,Name="Annually" }
            });

            context.Properties.AddOrUpdate(a => a.Id, new Property[]
            {
                new Property
                {
                    Id=1,
                    Name ="2000 Boulevard Ave,Scranton,PA,18509",
                    Unit="Second Floor"
                },
                new Property
                {
                    Id=2,
                    Name="301 N.Bromley Ave,Scranton, PA",
                    Unit="303"
                }
            });

            context.LeaseTypes.AddOrUpdate(a => a.Id, new LeaseType[]
            {
                new LeaseType {Id=1, Name="Leasing" },
                new  LeaseType { Id=2,Name="Month by month" }
            });

        }
    }
}
