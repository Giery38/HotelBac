using Hotel.API.GraphQL.Extensions;
using HotChocolate.Types.Descriptors;
using Hotel.API.GraphQL.Extensions;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;
using Hotel.API.GraphQL.Types.Models;
using Hotel.Application.Services.Data;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class QueryDataType<TEntity, TModel, TType, TQuery> : ObjectType<TQuery> 
        where TEntity : Entity
        where TModel : Model
        where TType : ObjectType<TModel>
        where TQuery : QueryData<TEntity, TModel, TType>
    {
        protected override void Configure(IObjectTypeDescriptor<TQuery> descriptor)
        {            
            Type type = this.GetType();
            descriptor.Name(type.Name);
            #region FIELDS
            descriptor
                .Field(f => f.Get())
                .Type<ListType<TType>>()
                .Name<TQuery>(f => nameof(f.Get));
            descriptor
                .Field(f => f.Add(default))
                .Type<StringType>()              
                .Name<TQuery>(f => nameof(f.Add));
            #endregion
        }
    }    
}
