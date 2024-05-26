using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations.Hotel
{
    public class RoomConfiguration : Configuration<RoomEntity>
    {
        public override void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasOne(c => c.Hotel)
                .WithMany(c => c.Rooms);
        }
    }
}