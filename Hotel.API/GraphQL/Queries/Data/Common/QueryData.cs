using HotChocolate.Types;
using Hotel.API.GraphQL.Types.Models;
using Hotel.Application.Services.Data;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data;
using Hotel.Data.Models;
using Z.Linq;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    public class QueryData<TEntity, TModel, TType>
        where TEntity : Entity
        where TModel : Model
        where TType : ObjectType<TModel>
    {
        private readonly IRepositoryServiceAsync<TEntity, TModel> repository;
        public QueryData([Service] IRepositoryServiceAsync<TEntity, TModel> repository)
        {
            this.repository = repository;
        }        
        [UseFiltering]        
        [UseSorting]
        public async Task<List<TModel>> Get()
        {
            return await repository.GetAll();
        }
        public async Task<string> Add(string item)
        {
            return "d";
            //await repository.Add()
        }
    }
}
