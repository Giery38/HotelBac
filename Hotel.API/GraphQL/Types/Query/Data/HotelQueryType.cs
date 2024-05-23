using Hotel.API.GraphQL.Queries.Data;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.API.GraphQL.Types.Models.Hotel;
using Hotel.Core.Models;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class HotelQueryType : QueryDataType<HotelEntity,HotelModel,HotelType>
    {
    }
}
