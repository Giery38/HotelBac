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
    public class RoomViewConfiguration : Configuration<RoomViewEntity>
    {
        public override void Configure(EntityTypeBuilder<RoomViewEntity> builder)
        {
            builder.HasMany(i => i.Rooms)
                .WithOne(c => c.View);
        }
    }
}
