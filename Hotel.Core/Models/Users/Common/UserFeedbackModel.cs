using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Users.Common
{
    public class UserFeedbackModel : Model
    {
        public UserModel User { get; private set; }
        public UserFeedbackTypes UserFeedbackType { get; private set; }
        public UserFeedbackModel(Guid id, UserModel user, UserFeedbackTypes userFeedbackType) : base(id)
        {
            User = user;
            UserFeedbackType = userFeedbackType;
        }
    }
}
