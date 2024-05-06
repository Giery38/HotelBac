using Hotel.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public interface IRepository
    {
        Task Add(IModel item);
        Task<IModel> Get(Guid id);
        Task<List<IModel>> GetAll();
        Task Update(IModel item);
        Task Delete(Guid id);
    }
}
