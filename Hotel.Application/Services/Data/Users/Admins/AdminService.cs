using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models;
using Hotel.Core.Models.Hotel;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Data
{
    public class AdminService : RepositoryService<AdminEntity, AdminModel>
    {
        public AdminService(IRepositoryAsync<AdminEntity> repository) : base(repository)
        {

        }
    }
}
