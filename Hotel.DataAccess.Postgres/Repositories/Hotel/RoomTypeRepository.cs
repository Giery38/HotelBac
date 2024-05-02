using Hotel.Core.DataAccess;
using Hotel.DataAccess.Postgres.Models.Hotel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Repositories.Hotel
{
    public class RoomTypeRepository : Repository<RoomTypeEntity>
    {
        public RoomTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
