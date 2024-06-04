using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Models.Users.Common
{
    public class UserEntity : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public Guid GenderId { get; set; }

        [ForeignKey(nameof(GenderId))]
        public GenderEntity? Gender { get; set; }
        public int Rating { get; set; } = 0;
        public List<UserFeedbackEntity> Feedbacks { get; set; } = [];
    }
}