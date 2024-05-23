using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class EnumTypeEntity : Entity
    {
        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
