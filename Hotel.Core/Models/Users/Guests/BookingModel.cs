using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class BookingModel : Model
    {
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; } 
        public decimal Cost { get; private set; } = 0;
        public List<RoomModel> Rooms { get; private set; } = [];
        public List<GuestModel> Guests { get; private set; } = [];

        public List<ServiceModel> Services { get; set; } = [];
        //services

    }
}
