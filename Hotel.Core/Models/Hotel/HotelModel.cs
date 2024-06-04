using Hotel.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Core.Models.Hotel
{
    public class HotelModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        public int Rating { get; set; } = 0;

        private int stars;
        public int Stars
        {
            get
            {
                return stars;
            }
            set
            {
                if (value > 5 || value < 0)
                {
                    throw new IndexOutOfRangeException(nameof(Stars));
                }
                stars = value;
            }
        }
        public List<RoomModel> Rooms { get; private set; } = [];
        public List<ServiceModel> Services { get; set; } = [];
        public HotelModel(Guid id, string name, string location, int rating, int stars, List<RoomModel> rooms, List<ServiceModel> services) : base(id)
        {
            Name = name;
            Location = location;
            Rating = rating;
            Stars = stars;
            Rooms = rooms;
            Services = services;
        }
        public HotelModel(Guid id, string name, string location, int rating, int stars, List<RoomModel> rooms, List<ServiceModel> services, bool setId) : base(id)
        {
            if (setId == true)
            {
                rooms.ForEach(i => i.SetHotel(this));
                services.ForEach(i => i.AddHotel(this));
            }
            Name = name;
            Location = location;
            Rating = rating;
            Stars = stars;
            Rooms = rooms;
            Services = services;
        }

        public void AddService(ServiceModel service)
        {
            Services.Add(service);
        }
    }
}
