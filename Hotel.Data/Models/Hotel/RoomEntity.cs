using Hotel.Data.Models.Hotel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Models
{
    public class RoomEntity : Entity
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public int Area { get; set; } = 0;
        public Guid ViewId { get; set; }

        [ForeignKey(nameof(ViewId))]
        public ViewTypeEntity? View { get; set; }

        public Guid RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public RoomTypeEntity? RoomType { get; set; } 
        public int Capacity { get; set; } = 0;
        public Guid HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public HotelEntity? Hotel { get; set; }
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}
