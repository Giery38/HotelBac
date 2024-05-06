using Hotel.Data.Models.Users.Guests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Hotel
{
    public class RoomTypeEntity : Entity
    {
        [Required]
        public string Value { get; set; } = string.Empty;
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}
