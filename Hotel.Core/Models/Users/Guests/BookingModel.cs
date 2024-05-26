using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;

namespace Hotel.Core.Models.Users.Guests
{
    public class BookingModel : Model
    {
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public decimal Cost { get; private set; } = 0;
        public List<RoomModel> Rooms { get; private set; } = [];
        public List<GuestModel> Guests { get; private set; } = [];
        public List<ServiceModel> Services { get; set; } = [];
        public BookingModel(Guid id, DateTime checkIn, DateTime checkOut, decimal cost, List<RoomModel> rooms, List<GuestModel> guests, List<ServiceModel> services) : base(id)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            Cost = cost;
            Rooms = rooms;
            Guests = guests;
            Services = services;
        }
    }
}