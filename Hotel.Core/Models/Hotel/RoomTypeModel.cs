using Hotel.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Hotel
{
    public class RoomTypeModel : BaseModel
    {
        public string Value { get; private set; } = string.Empty;
        public List<RoomModel> Rooms { get; private set; } = [];
        public RoomTypeModel(string value, List<RoomModel> rooms)
        {
            Value = value;
            Rooms = rooms;
        }
    }
}
