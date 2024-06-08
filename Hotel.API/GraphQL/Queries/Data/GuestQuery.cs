using Hotel.Data.Models.Users.Guests;
using Hotel.Data;
using Hotel.API.GraphQL.Queries.Data.Common;

namespace Hotel.API.GraphQL.Queries.Data
{
    [ExtendObjectType<QueryData>]
    public class GuestQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<GuestEntity>> GetGuests([Service] IRepositoryAsync<GuestEntity> repository)
        {
            return await repository.GetAll();
        }
        public async Task<bool> AddGuest([Service] IRepositoryAsync<GuestEntity> repository, GuestEntity item)
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
