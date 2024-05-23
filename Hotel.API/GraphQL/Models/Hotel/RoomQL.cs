namespace Hotel.API.GraphQL.Models.Hotel
{
    public class RoomQL : EntityQL
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public Guid RoomTypeId { get; set; }
        public RoomTypeQL? RoomType { get; set; }
        public int Occupancy { get; set; } = 0;
        public Guid HotelId { get; set; }
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}
