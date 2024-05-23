using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Core.Models
{
    public class HotelModel : Model
    {
   
     
       
        
        public string Name { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        private int stars;
        public int Stars
        {
            get
            {
                return stars;
            }
            private set
            {
                if (value > 5)
                {
                    stars = 5;
                    return;
                }
                if (value < 0)
                {
                    stars = 5;
                    return;
                }
                stars = value;
            }
        }
        public List<RoomModel> Rooms { get; private set; } = [];

        public List<ServiceModel> Services { get; set; } = [];
    }
}

}
