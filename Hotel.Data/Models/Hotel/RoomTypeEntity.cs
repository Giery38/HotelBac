using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models.Hotel
{
    public class RoomTypeEntity : EnumTypeEntity
    {        
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}
