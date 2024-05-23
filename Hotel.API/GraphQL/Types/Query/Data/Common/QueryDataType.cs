using Hotel.API.GraphQL.Extensions;
using HotChocolate.Types.Descriptors;
using Hotel.API.GraphQL.Extensions;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;
using Hotel.Application.Services.Data;
using Hotel.API.GraphQL.Types.Models.Users;
using Hotel.API.GraphQL.Types.Models.Hotel;
using Hotel.API.GraphQL.Types.Models.Common;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class QueryDataType<TEntity, TModel, TType> : ObjectType<QueryData<TEntity, TModel, TType>> 
        where TEntity : Entity
        where TModel : Model
        where TType : BaseDataObjectType<TModel>        
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData<TEntity, TModel, TType>> descriptor)
        {
            Type type = this.GetType();
            descriptor.Name(type.Name);
            #region FIELDS
            descriptor
                .Field(f => f.Get())
                .Type<ListType<TType>>()
                .Name<QueryData<TEntity, TModel, TType>>(f => nameof(f.Get));
            descriptor
                .Field(f => f.Add(default))
                .Argument("item", c => c.Type<Test>())
                .Name<QueryData<TEntity, TModel, TType>>(f => nameof(f.Add));
            #endregion
        }
    }  
    public class Test : InputObjectType<HotelEntity>
    {
        protected override void Configure(
        IInputObjectTypeDescriptor<HotelEntity> descriptor)
        {
            descriptor.Field(f => f.Id).Type<StringType>();
        }
    }
}
