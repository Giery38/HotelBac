using Hotel.Core.Models.Users.Common;

namespace Hotel.Core.Models.Users.Staff
{
    public class StaffModel : UserModel
    {
        public PositionTypeModel PositionType { get; set; }
        public StaffModel(Guid id, string name, DateOnly birthDate, GenderModel gender, int rating, List<UserFeedbackModel> feedbacks, PositionTypeModel positionType) : base(id, name, birthDate, gender, rating, feedbacks)
        {
            PositionType = positionType;
        }
        public StaffModel(Guid id, string name, DateOnly birthDate, GenderModel gender, int rating, List<UserFeedbackModel> feedbacks, PositionTypeModel positionType, bool setId) : base(id, name, birthDate, gender, rating, feedbacks, setId)
        {
            if (setId == true)
            {
                positionType.AddStaff(this);
            }
            PositionType = positionType;
        }
    }
}