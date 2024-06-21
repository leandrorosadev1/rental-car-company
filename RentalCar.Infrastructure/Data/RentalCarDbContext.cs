using Microsoft.EntityFrameworkCore;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Domain.Permissions;
using RentalCar.Domain.Rentals;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data.Configurations;
using RentalCar.Infrastructure.Data.Seeders;

namespace RentalCar.Infrastructure.Data
{
    public class RentalCarDbContext : DbContext
    {
        public RentalCarDbContext(DbContextOptions<RentalCarDbContext> options) : base(options)
        {

        }

        public RentalCarDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
            new CarBrandConfiguration().Configure(modelBuilder.Entity<CarBrand>());
            new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
            new CustomerUserConfiguration().Configure(modelBuilder.Entity<CustomerUser>());
            new RentalConfiguration().Configure(modelBuilder.Entity<Rental>());
            new PlatformRoleConfiguration().Configure(modelBuilder.Entity<PlatformRole>());
            new PlatformPermissionConfiguration().Configure(modelBuilder.Entity<PlatformPermission>());
            new CompanyUserConfiguration().Configure(modelBuilder.Entity<CompanyUser>());
            new CarCalendarConfiguration().Configure(modelBuilder.Entity<CarCalendar>());

            modelBuilder.Seed();
        }

        #region Tables
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<PlatformPermission> PlatformPermissions { get; set; }
        public DbSet<PlatformRole> PlatformRoles { get; set; }
        public DbSet<CarCalendar> CarCalendar { get; set; }
        #endregion

        #region Queries/SPs
        public DbSet<AvailableCar> AvailableCars { get; set; }
        #endregion

        public virtual async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => HasBaseEntity(x.Entity) && (x.State == EntityState.Added || x.State == EntityState.Modified));
            int? currentUserId = null;
            DateTime time = DateTime.UtcNow;

            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null)
            {
                bool isValidUserdId = int.TryParse(Thread.CurrentPrincipal.Identity.Name, out int parsedId);
                currentUserId = isValidUserdId ? parsedId : null;
            }

            foreach (var entity in entities)
            {
                BaseEntity baseEntity = entity.Entity as BaseEntity;

                if (baseEntity == null) continue;

                if (entity.State == EntityState.Added)
                {
                    baseEntity.CreatedDate = time;
                    baseEntity.CreatedUser = currentUserId;
                }

                baseEntity.ModifiedDate = time;
                baseEntity.ModifiedUser = currentUserId;
            }
        }

        private bool HasBaseEntity(object entity)
        {
            if (entity == null)
            {
                return false;
            }

            return HasBaseEntity(entity.GetType().BaseType);
        }

        private bool HasBaseEntity(Type type)
        {
            if (type == null)
            {
                return false;
            }

            if (type == typeof(BaseEntity))
            {
                return true;
            }
            else
            {
                return HasBaseEntity(type.BaseType);
            }
        }
    }
}
