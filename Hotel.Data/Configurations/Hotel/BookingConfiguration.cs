using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations
{
    public class BookingConfiguration : Configuration<BookingEntity>
    {
        public override void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasMany(c => c.Guests)
                .WithMany(c => c.Bookings);
            builder.HasMany(c => c.Rooms)
                .WithMany(c => c.Bookings);
        }
    }
}
