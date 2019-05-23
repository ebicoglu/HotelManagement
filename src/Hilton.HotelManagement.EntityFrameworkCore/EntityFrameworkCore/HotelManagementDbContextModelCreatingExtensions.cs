using Hilton.HotelManagement.HotelOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Users;

namespace Hilton.HotelManagement.EntityFrameworkCore
{
    public static class HotelManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureHotelManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(HotelManagementConsts.DbTablePrefix + "YourEntities", HotelManagementConsts.DbSchema);

            //    //...
            //});




            builder.Entity<Reservation>(b =>
            {
                b.ToTable(HotelManagementConsts.DbTablePrefix + "Reservation", HotelManagementConsts.DbSchema);

                b.Property(x => x.CheckinDate);
                b.Property(x => x.PersonCount);
                b.Property(x => x.IsPaid);
                b.Property(x => x.NameSurname);
                b.Property(x => x.Price);
                b.Property(x => x.TenantId);

            });

        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}