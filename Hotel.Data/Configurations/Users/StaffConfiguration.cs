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
    public class StaffConfiguration : Configuration<StaffEntity>
    {
        public override void Configure(EntityTypeBuilder<StaffEntity> builder)
        {
            builder.HasOne(c => c.PositionType)
                .WithMany(c => c.Staff);

        }
    }
}
