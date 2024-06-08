using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations.Users
{
    public class GuestConfiguration : Configuration<GuestEntity>
    {
        public override void Configure(EntityTypeBuilder<GuestEntity> builder)
        {
            builder.HasMany(c => c.Bookings)
                .WithMany(c => c.Guests);
            builder.HasMany(c => c.Feedbacks)
                .WithOne(c => c.Guest);
               
        }
    }
}