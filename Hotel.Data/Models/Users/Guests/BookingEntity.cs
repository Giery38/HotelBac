using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class BookingEntity : Entity
    {
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
        public decimal Cost { get; set; } = 0;
        services
        public List<RoomEntity> Rooms { get; set; } = [];
        public List<GuestEntity> Guests { get; set; } = [];
    }
}
