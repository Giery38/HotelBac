using Hotel.Core.Models.Users.Common;
using Hotel.Data.Models.Users.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Users
{
    public class UserFeedbackTypeConfiguration : Configuration<UserFeedbackTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<UserFeedbackTypeEntity> builder)
        {
            builder.HasMany(c => c.Feedbacks)
                .WithOne(c => c.FeedbackType);
        }
    }
}
