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
    public class UserFeedbackConfiguration : Configuration<UserFeedbackEntity>
    {
        public override void Configure(EntityTypeBuilder<UserFeedbackEntity> builder)
        {
            builder.HasOne(c => c.User)
                .WithMany(c => c.Feedbacks);
            builder.HasOne(c => c.FeedbackType)
                .WithMany(c => c.Feedbacks);
        }
    }
}
