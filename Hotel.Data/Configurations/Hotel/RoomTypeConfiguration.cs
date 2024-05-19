using Hotel.Data.Models.Hotel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations.Hotel
{
    public class RoomTypeConfiguration : Configuration<RoomTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<RoomTypeEntity> builder)
        {
            builder.HasMany(c => c.Rooms)
                .WithOne(c => c.RoomType);
        }
    }
}
