using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Hotel.Data.Models.Users.Common
{
    public class UserFeedbackEntity : Entity
    {
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }
        public string UserFeedbackType { get; set; } = string.Empty;
    }
}