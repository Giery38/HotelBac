using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Models.Users
{
    public abstract class UserEntity : Entity
    {
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Login { get; set; } = string.Empty;   
    }
}
