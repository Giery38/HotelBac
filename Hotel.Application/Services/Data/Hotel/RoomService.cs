using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models;
using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Data
{
    public class RoomService : RepositoryService<RoomEntity, RoomModel>
    {
        public RoomService(IRepositoryAsync<RoomEntity> repository) : base(repository)
        {
        }
    }
}
