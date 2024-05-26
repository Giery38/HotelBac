using Hotel.Data.Models.Users.Staff;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Users
{
    public class PositionTypeConfiguration : Configuration<PositionTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<PositionTypeEntity> builder)
        {
            builder.HasMany(c => c.Staff)
                .WithOne(c => c.PositionType);
        }
    }
}
