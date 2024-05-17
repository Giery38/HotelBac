using Hotel.Core.Models.Common;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL
{
    public class QueryType<TEntity, TModel, TType> : ObjectType<Query<TEntity, TModel>>
        where TEntity : Entity
        where TModel : Model
        where TType : ObjectType<TModel>
    {          
        protected override void Configure(IObjectTypeDescriptor<Query<TEntity, TModel>> descriptor)
        {
            descriptor
                .Field(f => f.GetAll())
                .Type<ListType<TType>>();
        }
    }
}
