using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Models.Hotel
{
    public class ServiceEntity : Entity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public Guid ServiceTypeId { get; set; }

        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceTypeEntity? ServiceType { get; set; }

        public List<HotelEntity> Hotels { get; set; } = [];
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}