namespace Hotel.API.GraphQL.Models.Hotel
{
    public class HotelQL : EntityQL
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Stars { get; set; } = 0;
    }
}
