using Hotel.Data;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Hotel.Analysis
{
    public static class Analizator
    {
        public static (StaffEntity staff ,int newStaffRating, GuestEntity guest, int newGuestRating) GetStaffPerfomance(FeedbackEntity guestFeedback)
        {
            int newStaffRating = 0;
            if (guestFeedback.Satisfied == true)
            {
                newStaffRating = guestFeedback.Staff.Rating + guestFeedback.Guest.Rating;
            }
            else
            {
                newStaffRating = guestFeedback.Staff.Rating - guestFeedback.Guest.Rating;
            }
            int newGuestRating = 0;
            if (guestFeedback.Guest.Feedbacks.Count != 0)
            {
                newGuestRating = guestFeedback.Guest.Bookings.Count / guestFeedback.Guest.Feedbacks.Count;
            }
            return (guestFeedback.Staff, newStaffRating, guestFeedback.Guest, newGuestRating);
        }
    }
}
