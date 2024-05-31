using Hotel.Core.Models.Common;
using Hotel.Core.Models.Users.Guests;

namespace Hotel.Core.Models.Hotel
{
    public class RoomModel : Model
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; private set; } = 0;
        public double Area { get; private set; } = 0;
        public int Rating { get; private set; } = 0;
        public RoomViewModel View { get; private set; }
        public RoomTypeModel RoomType { get; private set; }
        public int Capacity { get; private set; } = 0;
        public HotelModel Hotel { get; private set; }
        public List<BookingModel> Bookings { get; set; } = [];
        public RoomModel(Guid id, int number, decimal price, double area, int rating, RoomViewModel view,RoomTypeModel roomType, int capacity, HotelModel? hotel, List<BookingModel> bookings) : base(id)
        {
            Number = number;
            Price = price;
            Area = area;
            Rating = rating;
            View = view;
            RoomType = roomType;
            Capacity = capacity;
            Hotel = hotel;
            Bookings = bookings;
        }
        public RoomModel(Guid id, int number, decimal price, double area, int rating, int capacity) : base(id)
        {
            Number = number;
            Price = price;
            Area = area;
            Rating = rating;
            Capacity = capacity;
            Bookings = new List<BookingModel>();
        }
        public void SetHotel(HotelModel hotel)
        {
            Hotel = hotel;
        }
    }
}