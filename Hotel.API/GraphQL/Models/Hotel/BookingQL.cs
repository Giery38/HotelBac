
namespace Hotel.API.GraphQL.Models.Hotel
{
    public class BookingQL : EntityQL
    {
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public decimal Cost { get; private set; } = 0;
        public List<Guid> Rooms { get; private set; } = [];
        public List<Guid> Guests { get; private set; } = [];
        public List<Guid> Services { get; set; } = [];
    }
}
