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
        public List<BookingModel> Bookings { get; private set; } = [];

    }
}
