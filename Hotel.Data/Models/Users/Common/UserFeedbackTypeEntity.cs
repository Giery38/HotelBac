namespace Hotel.Data.Models.Users.Common
{
    public class UserFeedbackTypeEntity : TypeEntity
    {
        public List<UserFeedbackEntity> Feedbacks { get; set; } = [];
    }
}
