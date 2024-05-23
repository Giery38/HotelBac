using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models.Hotel
{
    public class ServiceTypeEntity : EnumTypeEntity
    {
        public List<ServiceEntity> Services { get; set; } = [];
    }
}
