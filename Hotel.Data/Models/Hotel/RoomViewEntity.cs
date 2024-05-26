namespace Hotel.Data.Models.Hotel
{
    public class RoomViewEntity : TypeEntity
    {
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}