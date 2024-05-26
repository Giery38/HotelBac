using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Users.Staff
{
    public class PositionTypeModel : TypeModel
    {
        public List<StaffModel> Staff { get; protected set; } = [];
        public PositionTypeModel(Guid id, string name, List<StaffModel> staff) : base(id, name)
        {
            Staff = staff;
        }
    }
}
