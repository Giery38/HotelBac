using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations
{
    public class GuestConfiguration : Configuration<GuestEntity>
    {
        public override void Configure(EntityTypeBuilder<GuestEntity> builder)
        {
            builder.HasMany(c => c.Bookings)
                .WithMany(c => c.Guests);
        }
    }
}
