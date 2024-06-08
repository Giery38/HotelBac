using HotChocolate.Language;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Relay;
using Hotel.Analysis;
using Hotel.API.GraphQL.Queries.Data;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.API.GraphQL.Types.Models.Input;
using Hotel.API.GraphQL.Types.Models.Input.Client;
using Hotel.API.GraphQL.Types.Models.Input.Common;
using Hotel.API.GraphQL.Types.Query.Common;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;
using System;
using System.Reflection;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class ClientQueryDataType : QueryDataType
    {        
        protected override void Configure(IObjectTypeDescriptor<QueryData> descriptor)
        {
            BaseInputObjectType<GuestEntity> GuestNoParams = new BaseInputObjectType<GuestEntity>("ForClient")
                .SetIgnorFields(f => f.GenderId, f => f.Gender
                , f => f.BirthDate, f => f.Bookings, f => f.Name, f => f.Feedbacks, f => f.Rating);
            descriptor.ExtendsType<BookingQuery>().Field<BookingQuery>(f => f.AddBookings(default, default)).Argument("item", o => o.Type(
                new InputClientType<BookingEntity>().SetTypeFields<DateTime>(f => f.CheckIn, f => f.CheckOut)
                .SetTypeFields(GuestNoParams, true, f => f.Guests).SetIgnorFields(f => f.Services, f => f.Rooms)));

            descriptor.ExtendsType<GuestQuery>().Field<GuestQuery>(f => f.AddGuest(default, default)).Argument("item", o => o.Type(
                new InputClientType<GuestEntity>().SetIgnorFields(f => f.Rating, f => f.Feedbacks)));

            descriptor.ExtendsType<FeedbackQuery>().Field<FeedbackQuery>(f => f.AddFeedback(default, default)).Argument("item", o => o.Type(
                new InputClientType<FeedbackEntity>().SetTypeFields(GuestNoParams, false, f => f.Guest))).Resolve(async c =>
                {
                    try
                    { 
                        FeedbackEntity feedback = c.ArgumentValue<FeedbackEntity>("item");
                        var result = Analizator.GetStaffPerfomance(feedback);
                        IRepositoryAsync<StaffEntity> staffRepository = c.Service<IRepositoryAsync<StaffEntity>>();
                        await staffRepository.Update(f => f.SetProperty(c => c.Rating, c => result.newStaffRating), result.staff.Id);
                        IRepositoryAsync<GuestEntity> guestRepository = c.Service<IRepositoryAsync<GuestEntity>>();
                        await guestRepository.Update(f => f.SetProperty(c => c.Rating, c => result.newGuestRating), result.guest.Id);
                        IRepositoryAsync<FeedbackEntity> feedbackRepository = c.Service<IRepositoryAsync<FeedbackEntity>>();
                        await feedbackRepository.Add(feedback);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;                        
                    }                                        
                });
        }
    }
}
