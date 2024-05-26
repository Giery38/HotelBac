using Hotel.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Users.Common
{
    public class UserFeedbackTypeModel : Model 
    {
        public List<UserFeedbackModel> Feedbacks { get; set; }
        public UserFeedbackTypes FeedbackType { get; private set; }             
        public UserFeedbackTypeModel(Guid id, List<UserFeedbackModel> feedbacks, UserFeedbackTypes feedbackType) : base(id)
        {
            Feedbacks = feedbacks;
            FeedbackType = feedbackType;
        }
    }
}
