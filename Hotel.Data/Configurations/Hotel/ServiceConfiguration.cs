using Hotel.Data.Models.Hotel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Hotel
{
    public class ServiceConfiguration : Configuration<ServiceEntity>
    {
        public override void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.HasOne(c => c.ServiceType)
                .WithMany(c => c.Services);
            builder.HasMany(c => c.Hotels)
                .WithMany(c => c.Services);
            builder.HasMany(c => c.Bookings)
                .WithMany(c => c.Services);
        }
    }
}
