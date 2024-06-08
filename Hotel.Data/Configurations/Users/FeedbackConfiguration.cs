using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Configurations.Users
{
    public class FeedbackConfiguration : Configuration<FeedbackEntity>
    {
        public override void Configure(EntityTypeBuilder<FeedbackEntity> builder)
        {
            builder.HasOne(c => c.Guest)
                .WithMany(c => c.Feedbacks);
            builder.HasOne(c => c.Staff)
                .WithMany(c => c.Feedbacks);
        }
    }
}
