using Hotel.Data.Models.Hotel;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models.Hotel
{
    public class HotelEntity : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public int Stars { get; set; } = 0;

        [Required]
        public List<RoomEntity> Rooms { get; set; } = [];

        public List<ServiceEntity> Services { get; set; } = [];
    }
}