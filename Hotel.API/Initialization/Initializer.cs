using Hotel.Data.Models.Users.Guests;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hotel.Data.Models.Users.Admins;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Application.Services.Data;
using Hotel.Core.Models;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Admins;
using Hotel.Core.Models.Users.Guests;

using Microsoft.Extensions.DependencyInjection;
using Hotel.API.GraphQL;

namespace Hotel.API.Initialization
{
    internal static class Initializer
    {
        private static WebApplicationBuilder? innerbBuilder;
        private static IServiceCollection? innerServices;
        public static WebApplicationBuilder Initialize(string[] args)
        {
            innerbBuilder = WebApplication.CreateSlimBuilder(args);
            innerServices = innerbBuilder.Services;
            ConfigurationManager configuration = innerbBuilder.Configuration;
            innerServices.AddControllers();
            innerServices.AddEndpointsApiExplorer();
            
            innerServices.AddGraphQLServer();
            innerServices.AddDbContext<HotelDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(HotelDbContext)));
                });           
            AddRepositories();
            AddRepositoryServices();           
            return innerbBuilder;
        }
        public static WebApplication Startup(WebApplicationBuilder builder)
        {
            WebApplication app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.MapControllers();
            app.MapGraphQL();
            app.Run();
            return app;
        }        
        private static void AddRepositories()
        {
            innerbBuilder.Services.AddScoped<IRepositoryAsync<AdminEntity>, Repository<AdminEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<AdminEntity>(hotelDbContext, nameof(hotelDbContext.Admins));
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<BookingEntity>, Repository<BookingEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<BookingEntity>(hotelDbContext, nameof(hotelDbContext.Bookings));
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<GuestEntity>, Repository<GuestEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<GuestEntity>(hotelDbContext, nameof(hotelDbContext.Guests));
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<HotelEntity>, Repository<HotelEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<HotelEntity>(hotelDbContext, nameof(hotelDbContext.Hotels));
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<RoomEntity>, Repository<RoomEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<RoomEntity>(hotelDbContext, nameof(hotelDbContext.Rooms));
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<RoomTypeEntity>, Repository<RoomTypeEntity>>(resolver =>
            {
                HotelDbContext? hotelDbContext = resolver.GetService<HotelDbContext>();
                return new Repository<RoomTypeEntity>(hotelDbContext, nameof(hotelDbContext.RoomTypes));
            });
        }
        private static void AddRepositoryServices()
        {
            innerServices.AddScoped<IRepositoryServiceAsync<AdminEntity, AdminModel>, RepositoryService<AdminEntity, AdminModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<BookingEntity, BookingModel>, RepositoryService<BookingEntity, BookingModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<GuestEntity, GuestModel>, RepositoryService<GuestEntity, GuestModel>>();
            innerbBuilder.Services.AddScoped<IRepositoryServiceAsync<HotelEntity, HotelModel>, RepositoryService<HotelEntity, HotelModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<RoomEntity, RoomModel>, RepositoryService<RoomEntity, RoomModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<RoomTypeEntity, RoomTypeModel>, RepositoryService<RoomTypeEntity, RoomTypeModel>>();
        }
    }
}
