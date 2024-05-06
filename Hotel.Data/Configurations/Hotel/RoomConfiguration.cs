using Hotel.Data.Configurations;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations
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
