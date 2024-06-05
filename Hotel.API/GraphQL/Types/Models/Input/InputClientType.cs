using Hotel.API.GraphQL.Types.Models.Input.Common;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Models.Input
{
    public class InputClientType<TEntity> : BaseInputObjectType<TEntity>
       where TEntity : Entity
    {
        protected override void Configure(IInputObjectTypeDescriptor<TEntity> descriptor)
        {
            descriptor.Field(f => f.Id).Ignore();
            base.Configure(descriptor);
        }
    }
}
