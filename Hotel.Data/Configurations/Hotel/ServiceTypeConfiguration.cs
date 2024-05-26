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
    public class ServiceTypeConfiguration : Configuration<ServiceTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<ServiceTypeEntity> builder)
        {
            builder.HasMany(c => c.Services)
                .WithOne(c => c.ServiceType);
        }
    }
}
