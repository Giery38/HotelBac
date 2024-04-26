using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Models
{
    public class RoomEntity : Entity
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public string RoomType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Occupancy { get; set; } = 0;
        public List<string> Photos { get; set; } = [];
        public Guid HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public HotelEntity? Hotel { get; set; }
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}
