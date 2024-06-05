using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.API.GraphQL.Types.Models.Input;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class ClientQueryDataType<TEntity> : ObjectType<QueryData<TEntity>>
        where TEntity : Entity
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData<TEntity>> descriptor)
        {
            descriptor.Field(f => f.Add(default)).Argument("item", a => a.Type<NonNullType<InputClientType<TEntity>>>());
            base.Configure(descriptor);
        }
    }
}
