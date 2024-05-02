using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Users.Guests
{
    public class BookingModel
    {
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; } 
        public decimal Value { get; private set; } = 0;
        public bool Paid { get; private set; } = false;
        public List<RoomModel> Rooms { get; private set; } = [];
        public List<GuestModel> Guests { get; private set; } = [];
        public BookingModel(DateTime checkIn, DateTime checkOut, decimal value, bool paid, List<RoomModel> rooms, List<GuestModel> guests)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            Value = value;
            Paid = paid;
            Rooms = rooms;
            Guests = guests;
        }
    }
}
