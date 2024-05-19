using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models.Hotel
{
    public class RoomTypeEntity : Entity
    {
        [Required]
        public string Value { get; set; } = string.Empty;
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}
