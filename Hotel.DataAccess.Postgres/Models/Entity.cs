
using System.ComponentModel.DataAnnotations;

namespace Hotel.DataAccess.Postgres.Models
{
    public class Entity 
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
    }
}
