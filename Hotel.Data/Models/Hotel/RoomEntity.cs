using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Guests;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Models.Hotel
{
    public class RoomEntity : Entity
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public double Area { get; set; } = 0;
        public int Rating { get; set; } = 0;
        public Guid ViewId { get; set; }

        [ForeignKey(nameof(ViewId))]
        public RoomViewEntity? View { get; set; }
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