using Hotel.Data.Models;
using Hotel.Data;
using Hotel.Data.Models.Users.Guests;
using Hotel.API.GraphQL.Queries.Data.Attributes;

namespace Hotel.API.GraphQL.Queries.Data
{
    public partial class QueryData
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<BookingEntity>> GetBookings([Service] IRepositoryAsync<BookingEntity> repository)
        {
            return await repository.GetAll();
        }
        [Add]
        
        public async Task<bool> AddBookings([Service] IRepositoryAsync<BookingEntity> repository, BookingEntity item)
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
