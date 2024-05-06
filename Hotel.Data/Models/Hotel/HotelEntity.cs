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
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public int Stars { get; set; } = 0; // сделать класс старс
        public List<string> Photos { get; set; } = [];
        [Required]        
        public List<RoomEntity> Rooms { get; set; } = [];
    }
}
