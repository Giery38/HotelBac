using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models.Users.Common
{
    public class GenderEntity : TypeEntity
    {
        public List<UserEntity> Users { get; set; } = [];
    }
}
