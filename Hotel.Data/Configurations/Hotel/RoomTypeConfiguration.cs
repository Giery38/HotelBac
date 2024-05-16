using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
