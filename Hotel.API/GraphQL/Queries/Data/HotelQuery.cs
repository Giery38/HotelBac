using Hotel.Data.Models.Users.Guests;
using Hotel.Data;
using Hotel.Data.Models.Hotel;
using System.Linq.Expressions;
using Hotel.API.GraphQL.Queries.Data.Common;

namespace Hotel.API.GraphQL.Queries.Data
{
    [ExtendObjectType<QueryData>]
    public class HotelQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<HotelEntity>> GetHotels([Service] IRepositoryAsync<HotelEntity> repository)
        {
            return await repository.GetAll(new Expression<Func<HotelEntity, object>>[] { a => a.Services, a => a.Rooms });
        }
        public async Task<bool> AddHotel([Service] IRepositoryAsync<HotelEntity> repository, HotelEntity item)
        {
            try
            {
                await repository.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
   
}
