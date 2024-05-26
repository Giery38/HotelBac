using Hotel.Core.Models.Common;
using Hotel.Core.Models.Users.Guests;

namespace Hotel.Core.Models.Hotel
{
    public class ServiceModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = 0;
        public ServiceTypeModel ServiceType { get; private set; }
        public List<HotelModel> Hotels { get; private set; } = [];
        public List<BookingModel> Bookings { get; private set; } = [];
        public ServiceModel(Guid id, string name, decimal price, ServiceTypeModel serviceType, List<HotelModel> hotels, List<BookingModel> bookings) : base(id)
        {
            Name = name;
            Price = price;
            ServiceType = serviceType;
            Hotels = hotels;
            Bookings = bookings;
        }
    }
}