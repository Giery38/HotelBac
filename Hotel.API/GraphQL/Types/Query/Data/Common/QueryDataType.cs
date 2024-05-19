using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class QueryDataType<TEntity, TModel, TType, TQuery> : ObjectType<TQuery>  //QueryData<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
        where TType : ObjectType<TModel>
        where TQuery : QueryData<TEntity, TModel>
    {
        protected override void Configure(IObjectTypeDescriptor<TQuery> descriptor)
        {
            descriptor
                .Field(f => f.GetAll())
                .Type<ListType<TType>>();
        }
    }
}
