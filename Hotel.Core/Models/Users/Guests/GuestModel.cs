
using Hotel.Core.Models.Users.Common;

namespace Hotel.Core.Models.Users.Guests
{
    public class GuestModel : UserModel
    {
        public List<BookingModel> Bookings { get; private set; } = [];
        public GuestModel(Guid id, string name, DateOnly birthDate, GenderModel gender, int rating, List<UserFeedbackModel> feedbacks, List<BookingModel> bookings) : base(id, name, birthDate, gender, rating, feedbacks)
        {
            Bookings = bookings;
        }
    }
}