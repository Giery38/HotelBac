using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Users.Admins
{
    public class AdminModel : UserModel
    {
        public AdminModel(Guid id, string password, string login) : base(id, password, login)
        {
        }
    }
}
