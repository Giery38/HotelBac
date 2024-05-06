using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Guests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class RoomModel : Model
    {
        public int Number { get; set; } = 0;
        public decimal Price { get; private set; } = 0;
        public RoomTypeModel RoomType { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Occupancy { get; private set; } = 0;
        public List<string> Photos { get; private set; } = [];
        public HotelModel Hotel { get; private set; }
        public List<BookingModel> Bookings { get; set; } = [];
        public RoomModel(int number, decimal price, RoomTypeModel roomType, string description, int occupancy, List<string> photos, HotelModel hotel, List<BookingModel> bookings)
        {
            Number = number;
            Price = price;
            RoomType = roomType;
            Description = description;
            Occupancy = occupancy;
            Photos = photos;
            Hotel = hotel;
            Bookings = bookings;
        }

    }
}
