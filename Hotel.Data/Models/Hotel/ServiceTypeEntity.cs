namespace Hotel.Data.Models.Hotel
{
    public class ServiceTypeEntity : TypeEntity
    {
        public List<ServiceEntity> Services { get; set; } = [];
    }
}