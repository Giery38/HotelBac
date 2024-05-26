using System.ComponentModel.DataAnnotations.Schema;
using Hotel.Data.Models.Users.Common;

namespace Hotel.Data.Models.Users.Staff
{
    public class StaffEntity : UserEntity
    {
        public Guid PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public PositionTypeEntity? PositionType { get; set; }
    }
}