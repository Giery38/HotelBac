using Hotel.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Repositories
{
    public interface IRepository
    {
        Task Add(IModel item);
        Task<IModel> Get(Guid id);
        Task Update(IModel item);
        Task Delete(Guid id);
    }
}
