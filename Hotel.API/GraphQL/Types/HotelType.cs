using Hotel.Core.Models;

namespace Hotel.API.GraphQL.Types
{
    public class HotelType : ObjectType<HotelModel>
    {
        protected override void Configure(IObjectTypeDescriptor<HotelModel> descriptor)
        {
            
        }
    }
}
