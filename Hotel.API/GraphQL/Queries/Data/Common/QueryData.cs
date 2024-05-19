using HotChocolate.Types;
using Hotel.Application.Services.Data;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data;
using Hotel.Data.Models;
using Z.Linq;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    public class QueryData<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        private readonly IRepositoryServiceAsync<TEntity, TModel> repository;
        public QueryData([Service] IRepositoryServiceAsync<TEntity, TModel> repository)
        {
            this.repository = repository;
        }
        public async Task<List<TModel>> GetAll()
        {
            return await repository.GetAll();
        }
    }
}
