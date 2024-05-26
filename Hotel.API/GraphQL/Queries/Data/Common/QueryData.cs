using Hotel.API.GraphQL.Models;
using Hotel.API.GraphQL.Models.Hotel;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Core.Models.Users.Guests;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using System.ComponentModel;

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
            var tt = await repository.GetAll();
            return new List<TEntityQL>();
            //return await repository.GetAll();
        }   
        public async Task<List<Guid>> GetId()
        {
            return new List<Guid>();
        }
        public string Add(TEntityQL item)
        {
            //var tt = EntityConverter.ToModel(item);
            return  "s";
            //await repository.Add()
        }
    }
    public class Test<TEntity, TModel, TEntityQL> : ObjectType<QueryData<TEntity, TModel, TEntityQL>>
        where TEntity : Entity
        where TModel : Model
        where TEntityQL : EntityQL 
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData<TEntity, TModel, TEntityQL>> descriptor)
        {
            
        }
    }
}