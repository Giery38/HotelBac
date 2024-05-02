using Hotel.Core.DataAccess;
using Hotel.DataAccess.Postgres.Models;
using Hotel.DataAccess.Postgres.Models.Users.Admins;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Postgres.Repositories.Users
{
    public class AdminRepository : Repository<AdminEntity>
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
         
        }
    }
}
