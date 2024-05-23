using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Hotel
{
    public class ViewTypeEntity : EnumTypeEntity
    {
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}
