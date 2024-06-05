using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}