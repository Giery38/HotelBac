using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class GuestEntity : UserEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string BirthDay { get; set; } = string.Empty;
        [Required]
        public string PassportNumber { get; set; } = string.Empty;
        public List<BookingEntity> Bookings { get; set; } = [];
    }
}
