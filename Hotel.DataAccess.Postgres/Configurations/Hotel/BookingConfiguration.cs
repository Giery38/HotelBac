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
