
using System.ComponentModel.DataAnnotations;

namespace Hotel.DataAccess.Postgres.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
