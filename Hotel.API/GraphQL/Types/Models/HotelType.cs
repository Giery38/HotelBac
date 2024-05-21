using Hotel.API.GraphQL.Types.Models.Common;
using Hotel.Core.Models;

namespace Hotel.API.GraphQL.Types.Models
{
    public class HotelType : BaseDataObjectType<HotelModel>
    {
        public HotelType()
        {
           
        }
        protected override void CustomConfigure(IObjectTypeDescriptor<HotelModel> descriptor)
        {
            
        }
    }
}
