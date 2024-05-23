using Hotel.API.GraphQL.Models;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    public class QueryData<TEntity, TModel, TEntityQL>
        where TEntity : Entity
        where TModel : Model
        where TEntityQL : EntityQL
    {
        private readonly IRepositoryServiceAsync<TEntity, TModel> repository;
        public QueryData([Service] IRepositoryServiceAsync<TEntity, TModel> repository)
        {
            this.repository = repository;
        }        
        [UseFiltering]        
        [UseSorting]
        public async Task<List<TEntityQL>> Get()
        {
            return new List<TEntityQL>();
            //return await repository.GetAll();
        }
        public TModel Add(TEntityQL item)
        {
            //var tt = EntityConverter.ToModel(item);
            return default;
            //await repository.Add()
        }
    }
}
