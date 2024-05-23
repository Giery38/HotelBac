using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Users.Guests
{
    public class GuestFeedbackEntity : Entity
    {
        public int Satisfied { get; set; } = 0;
    }
}
