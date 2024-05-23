using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Users
{
    public class PositionTypeEntity : EnumTypeEntity
    {
        public List<StaffEntity> Staff { get; set; } = [];
    }
}
