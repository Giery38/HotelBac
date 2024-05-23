using Hotel.Data.Models.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class HotelEntity : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        public int Stars { get; set; } = 0;
        [Required]        
        public List<RoomEntity> Rooms { get; set; } = [];

        public List<ServiceEntity> Services { get; set; } = [];
    }
}
