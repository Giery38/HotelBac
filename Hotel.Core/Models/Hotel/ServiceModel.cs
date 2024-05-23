using Hotel.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Hotel
{
    public class ServiceModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = 0;
        //public ServiceTypeEntity? ServiceType { get; set; }
        public List<HotelModel> Hotels { get; private set; } = [];
    }
}
