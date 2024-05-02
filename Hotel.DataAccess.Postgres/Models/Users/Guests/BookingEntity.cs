using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Models.Users.Guests
{
    public class BookingEntity : Entity
    {
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
        public decimal Value { get; set; } = 0;
        public bool Paid { get; set; } = false;
        public List<RoomEntity> Rooms { get; set; } = [];
        public List<GuestEntity> Guests { get; set; } = [];
    }
}
