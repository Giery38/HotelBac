using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class GuestModel : UserModel
    {
        public string Name { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly BirthDay { get; private set; } 
        public string PassportNumber { get; private set; } = string.Empty;
        public List<BookingModel> Bookings { get; set; } = [];
        public GuestModel(Guid id, string password, string login, string name, string phone, DateOnly birthDay, string passportNumber, List<BookingModel> bookings) : base(id, password, login)
        {
            Name = name;
            Phone = phone;
            BirthDay = birthDay;
            PassportNumber = passportNumber;
            Bookings = bookings;
        }
    }
}
