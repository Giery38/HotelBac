using Hotel.API.GraphQL.Models;
using Hotel.API.GraphQL.Models.Hotel;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Core.Models.Users.Guests;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;

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

        public string Add(TEntityQL item)
        {
            //var tt = EntityConverter.ToModel(item);
            return  "s";
            //await repository.Add()
        }
    }
    public class Test : ObjectType<QueryData<BookingEntity,BookingModel,BookingQL>>
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData<BookingEntity, BookingModel, BookingQL>> descriptor)
        {

        }
    }
}