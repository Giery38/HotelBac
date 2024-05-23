using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Hotel.API.GraphQL.Types.Models.Hotel;
using Hotel.Core.Models;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Models.Common
{
    public class BaseDataObjectType<TModel> : ObjectType<TModel>
    where TModel : Model
    {

        protected override void Configure(IObjectTypeDescriptor<TModel> descriptor)
        {
            Type type = this.GetType();
            string name = type.Name;
            if (name is null)
            {
                throw new ArgumentNullException(nameof(type.Name));
            }
            descriptor.Name(type.Name);
            CustomConfigure(descriptor);
        }
        protected virtual void CustomConfigure(IObjectTypeDescriptor<TModel> descriptor)
        {

        }

    }

}
