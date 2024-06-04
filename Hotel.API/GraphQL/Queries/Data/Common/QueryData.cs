using Hotel.API.GraphQL.Models;
using Hotel.API.GraphQL.Models.Hotel;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    public class QueryData<TEntity> 
        where TEntity : Entity
    {
        private readonly IRepositoryAsync<TEntity> repository;

        public QueryData([Service] IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }

        [UseFiltering]
        [UseSorting]
        public async Task<List<TEntity>> Get(Predicate<TEntity> predicate)
        {
            return await repository.GetAll();
        }
        public string Add(TEntity item)
        {
            return "s";
            //await repository.Add()
        }
    }
    public class Test<TEntity> : ObjectType<QueryData<TEntity>>
        where TEntity : Entity
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData<TEntity>> descriptor)
        {
          
        }
    }
    
}