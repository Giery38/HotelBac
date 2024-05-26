using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Users.Common
{
    public abstract class UserModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public DateOnly BirthDate { get; private set; }
        public GenderModel Gender { get; private set; } 
        public int Rating { get; private set; } = 0;
        public List<UserFeedbackModel> Feedbacks { get; set; } = [];
        protected UserModel(Guid id, string name, DateOnly birthDate, GenderModel gender, int rating, List<UserFeedbackModel> feedbacks) : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Rating = rating;
            Feedbacks = feedbacks;
        }
    }
}