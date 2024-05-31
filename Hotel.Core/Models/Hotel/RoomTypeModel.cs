using Hotel.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Hotel
{
    public class RoomTypeModel : TypeModel
    {
        public List<RoomModel> Rooms { get; set; } = [];
        public RoomTypeModel(Guid id, string name, List<RoomModel> rooms) : base(id, name)
        {
            Rooms = rooms;
        }
        public RoomTypeModel(Guid id, string name) : base(id, name)
        {
            Rooms = new List<RoomModel>();
        }
        public void AddRoom(RoomModel room)
        {
            Rooms.Add(room);
        }
    }
}
