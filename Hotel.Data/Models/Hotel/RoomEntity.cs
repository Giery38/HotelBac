using Hotel.Data.Models.Hotel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Models
{
    public class RoomEntity : Entity
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public Guid RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public RoomTypeEntity? RoomType { get; set; } 
        public string Description { get; set; } = string.Empty;
        public int Occupancy { get; set; } = 0;
        public List<string> Photos { get; set; } = [];
        public Guid HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public HotelEntity? Hotel { get; set; }
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}
