using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations.Hotel
{
    public class HotelConfiguration : Configuration<HotelEntity>
    {
        public override void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.HasMany(c => c.Rooms)
               .WithOne(c => c.Hotel);
        }
    }
}