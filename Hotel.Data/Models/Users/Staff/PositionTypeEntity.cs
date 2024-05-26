namespace Hotel.Data.Models.Users.Staff
{
    public class PositionTypeEntity : TypeEntity
    {
        public List<StaffEntity> Staff { get; set; } = [];
    }
}