using Hotel.Data.Models.Users.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Users
{
    public class GenderConfiguration : Configuration<GenderEntity>
    {
        public override void Configure(EntityTypeBuilder<GenderEntity> builder)
        {
            builder.HasMany(c => c.Users)
                .WithOne(c => c.Gender);
        }
    }
}
