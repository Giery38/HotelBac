namespace Hotel.Data.Models.Hotel
{
    public class RoomTypeEntity : TypeEntity
    {
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}