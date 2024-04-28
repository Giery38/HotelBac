using Hotel.Core.DataAccess;
using Hotel.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Repositories.Hotel
{
    public class BookingRepository : Repository<BookingEntity>
    {
        public BookingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
