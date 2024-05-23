using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class StaffEntity : UserEntity
    {
        public Guid PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public PositionTypeEntity? PositionType { get; set; }
    }
}
