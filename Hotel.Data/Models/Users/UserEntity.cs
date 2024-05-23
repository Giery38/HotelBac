using Hotel.Data.Models.Users.Guests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public abstract class UserEntity : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Rating {  get; set; } = 0;
        public List<GuestFeedbackEntity> GuestFeedbacks { get; set; } = [];
    }
}