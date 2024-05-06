using Hotel.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models
{
    public abstract class Entity : IModel
    {   
        [Key]
        public Guid Id { get; set; }
    }
}
