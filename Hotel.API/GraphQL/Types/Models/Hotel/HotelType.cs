using Hotel.API.GraphQL.Types.Models.Common;
using Hotel.Core.Models;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Models.Hotel
{
    public class HotelType : BaseDataObjectType<HotelModel>
    {
        public HotelType()
        {

        }
        protected override void CustomConfigure(IObjectTypeDescriptor<HotelModel> descriptor)
        {
            descriptor.Field(f => f.Id).Type<StringType>();
        }
    }
}
