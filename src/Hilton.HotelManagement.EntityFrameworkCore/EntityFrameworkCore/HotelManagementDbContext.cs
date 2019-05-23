using Hilton.HotelManagement.HotelOperations;
using Microsoft.EntityFrameworkCore;
using Hilton.HotelManagement.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Hilton.HotelManagement.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class HotelManagementDbContext : AbpDbContext<HotelManagementDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.ConfigureAbpUser();

                //Moved customization to a method so we can share it with the HotelManagementMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureHotelManagement method */

            builder.ConfigureHotelManagement();
        }
    }
}