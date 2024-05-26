using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Users.Common
{
    public class UserFeedbackModel : Model
    {
        public UserModel User { get; private set; }
        public UserFeedbackTypeModel UserFeedback { get; private set; }
        public UserFeedbackModel(Guid id, UserModel user, UserFeedbackTypeModel userFeedback) : base(id)
        {
            User = user;
            UserFeedback = userFeedback;
        }
    }
}
