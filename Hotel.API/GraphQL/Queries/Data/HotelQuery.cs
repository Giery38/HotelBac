using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models;
using Hotel.Data.Models;

namespace Hotel.API.GraphQL.Queries.Data
{
    public class HotelQuery : QueryData<HotelEntity, HotelModel>
    {
        public HotelQuery([Service(ServiceKind.Default)] IRepositoryServiceAsync<HotelEntity, HotelModel> repository) : base(repository)
        {
        }
    }
}
