using HotChocolate.Types;
using Hotel.API.GraphQL.Types.Models.Common;
using Hotel.API.GraphQL.Types.Models.Hotel;
using Hotel.API.GraphQL.Types.Models.Users;
using Hotel.API.GraphQL.Types.Query.Data;
using Hotel.Application.Converters;
using Hotel.Application.Services.Data;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data;
using Hotel.Data.Models;
using System.Dynamic;
using Z.Linq;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    public class QueryData<TEntity, TModel, TType>
        where TEntity : Entity
        where TModel : Model
        where TType : BaseDataObjectType<TModel>
    {
        private readonly IRepositoryServiceAsync<TEntity, TModel> repository;
        public QueryData([Service] IRepositoryServiceAsync<TEntity, TModel> repository)
        {
            this.repository = repository;
        }        
        [UseFiltering]        
        [UseSorting]
        public async Task<List<TType>> Get()
        {
            return new List<TType>();
            //return await repository.GetAll();
        }
        public TModel Add(Test item)
        {
            //var tt = EntityConverter.ToModel(item);
            return default;
            //await repository.Add()
        }
    }
}
