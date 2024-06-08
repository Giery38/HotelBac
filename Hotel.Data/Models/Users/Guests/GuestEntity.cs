using Hotel.Data.Models.Users.Common;

namespace Hotel.Data.Models.Users.Guests
{
    public class GuestEntity : UserEntity
    {
        public List<BookingEntity> Bookings { get; set; } = [];

        public List<FeedbackEntity> Feedbacks { get; set; } = [];
    }
}