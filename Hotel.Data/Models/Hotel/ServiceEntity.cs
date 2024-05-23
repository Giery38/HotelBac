using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Hotel
{
    public class ServiceEntity
    {
        public Guid ServiceTypeId { get; set; }
        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceTypeEntity? ServiceType { get; set; }
    }
}
