using Hotel.Data.Models.Users.Guests;
using Hotel.Data;
using Hotel.API.GraphQL.Queries.Data.Common;

namespace Hotel.API.GraphQL.Queries.Data
{
    [ExtendObjectType<QueryData>]
    public class FeedbackQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<FeedbackEntity>> GetFeedbacks([Service] IRepositoryAsync<FeedbackEntity> repository)
        {
            return await repository.GetAll();
        }
        public async Task<bool> AddFeedback([Service] IRepositoryAsync<FeedbackEntity> repository, FeedbackEntity item)
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
