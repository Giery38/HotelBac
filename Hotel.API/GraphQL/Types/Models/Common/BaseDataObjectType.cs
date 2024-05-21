using Hotel.Core.Models;
using Hotel.Core.Models.Common;

namespace Hotel.API.GraphQL.Types.Models.Common
{
    public class BaseDataObjectType<TModel> : ObjectType<TModel>, IOutputType
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
