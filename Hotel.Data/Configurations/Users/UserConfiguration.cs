using Hotel.Data.Configurations;
using Hotel.Data.Models.Users.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Users
{
    public class UserConfiguration : Configuration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasOne(c => c.Gender)
                .WithMany(c => c.Users);
        }
    }
}
