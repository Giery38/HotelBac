using HotChocolate.Types;
using Hotel.Application.Services.Data;
using Hotel.Core.Models.Common;
using Hotel.Data;
using Hotel.Data.Models;
using Z.Linq;

namespace Hotel.API.GraphQL
{
    public class Query<TEntity, TModel> 
        where TEntity : Entity
        where TModel :  Model
    {
        private readonly IRepositoryServiceAsync<TEntity, TModel> repository;
        public Query([Service] IRepositoryServiceAsync<TEntity, TModel> repository)
        {
            this.repository = repository;
        }       
        public async Task<List<TModel>> GetAll()
        {
            var tt = await repository.GetAll(); 
            return await repository.GetAll();
        }
    }
}
