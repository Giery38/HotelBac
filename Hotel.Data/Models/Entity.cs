using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}