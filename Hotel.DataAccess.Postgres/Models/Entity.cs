using Hotel.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Hotel.DataAccess.Postgres.Models
{
    public abstract class Entity : IModel
    {   
        [Key]
        public Guid Id { get; set; }
    }
}
