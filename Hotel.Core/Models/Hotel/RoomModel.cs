using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
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
        public int Area { get; private set; } = 0;
        // view сюда
        public RoomTypeModel RoomType { get; private set; } //чекни хз
        public int Capacity { get; private set; } = 0;
        public HotelModel Hotel { get; private set; }
        public List<BookingModel> Bookings { get; set; } = [];

    }
}
