using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
    }
}
