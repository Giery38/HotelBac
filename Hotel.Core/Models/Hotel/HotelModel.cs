﻿using Hotel.Core.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Core.Models
{
    public class HotelModel : BaseModel
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;      
        public int Stars 
        { 
            get
            {
                return Stars;
            }
            private set
            {
                if (value > 5)
                {
                    Stars = 5;
                }
                if (value < 0)
                {
                    Stars = 5;
                }
            }
        }
        public List<string> Photos { get; private set; } = [];
        public HotelModel(string name, string description, string address, string phone, int stars, List<string> photos)
        {
            Name = name;
            Description = description;
            Address = address;
            Phone = phone;
            Stars = stars;
            Photos = photos;
        }
    }
}
