using Hotel.Data.Models.Hotel;

namespace Hotel.Data.Models.Users.Guests
{
    public class BookingEntity : Entity
    {
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
        public decimal Cost { get; set; } = 0;
        public List<ServiceEntity> Services { get; set; } = [];
        public List<RoomEntity> Rooms { get; set; } = [];
        public List<GuestEntity> Guests { get; set; } = [];
    }
}