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
    public class GuestConfiguration : Configuration<GuestEntity>
    {
        public override void Configure(EntityTypeBuilder<GuestEntity> builder)
        {
            builder.HasMany(c => c.Bookings)
                .WithMany(c => c.Guests);
        }
    }
}
