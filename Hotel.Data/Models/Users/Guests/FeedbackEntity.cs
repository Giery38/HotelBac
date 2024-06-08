using System.ComponentModel.DataAnnotations.Schema;
using System;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Staff;

namespace Hotel.Data.Models.Users.Guests
{
    public class FeedbackEntity : Entity
    {
        public Guid GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        public GuestEntity? Guest { get; set; }
        public Guid StaffId { get; set; }

        [ForeignKey(nameof(StaffId))]
        public StaffEntity? Staff { get; set; } 
        public bool Satisfied { get; set; }
    }
}