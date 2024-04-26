using Hotel.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Configurations
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
