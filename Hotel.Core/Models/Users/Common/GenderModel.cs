using Hotel.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Users.Common
{
    public class GenderModel : Model
    {
        public Genders Gender { get; private set; } = Genders.none;
        public List<UserModel> Users { get; private set; } = [];
        public GenderModel(Guid id, Genders gender, List<UserModel> users) : base(id)
        {
            Gender = gender;
            Users = users;
        }
        public GenderModel(Guid id, Genders gender) : base(id)
        {
            Gender = gender;
            Users = new List<UserModel>();
        }
        public void AddUser(UserModel user)
        {
            Users.Add(user);
        }
    }
}
