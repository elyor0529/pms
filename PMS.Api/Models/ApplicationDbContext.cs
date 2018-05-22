using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PMS.Api.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web;
using System.Threading.Tasks;

namespace PMS.Api.Models
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public static void Initializer()
        {
            // Set the database intializer which is run once during application start
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
            Database.CommandTimeout = 3600;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            Configuration.UseDatabaseNullSemantics = true;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<JELine> JELines { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<SaasEcomUser> SaasEcomUsers { get; set; }
        public virtual DbSet<SubscriptionPlanProperty> SubscriptionPlanProperties { get; set; }
        public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<FinacialAccount> FinacialAccounts { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<ContactInfoType> ContactInfoTypes { get; set; }
        public virtual DbSet<ContactInfoUsageType> ContactInfoUsageTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Lease> Leases { get; set; }
        public virtual DbSet<LeaseFile> LeaseFiles { get; set; }
        public virtual DbSet<LeaseType> LeaseTypes { get; set; }
        public virtual DbSet<PaymentFrequency> PaymentFrequencies { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PrincipalRelationType> PrincipalRelationTypes { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertySubType> PropertySubTypes { get; set; }
        public virtual DbSet<PropertyTenantMap> PropertyTenantMaps { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<RecordStatus> RecordStatuses { get; set; }
        public virtual DbSet<RentalStatus> RentalStatuses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TenantAddressMap> TenantAddressMaps { get; set; }
        public virtual DbSet<TenantContactInfoMap> TenantContactInfoMaps { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Appliance> Appliances { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public virtual DbSet<TenantAccess> TenantAccesses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => SaveChanges(), cancellationToken);
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.Entity is BaseEntity
                                && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    var entity = (BaseEntity)entry.Entity;
                    var identity = Thread.CurrentPrincipal.Identity.GetUserId();
                    var now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identity;
                        entity.CreatedOn = now;
                        entity.IsActive = true;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                    }

                    entity.UpdatedBy = identity;
                    entity.UpdatedOn = now;
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}