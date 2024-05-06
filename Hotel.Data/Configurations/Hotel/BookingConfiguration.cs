using Hotel.Data.Configurations;
using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations
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
