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
using Hotel.API.GraphQL.Types;
using Hotel.Data.Configurations;

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
            AddGraphQLConfigure(configuration);
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
        private static void AddGraphQLConfigure(ConfigurationManager configuration)
        {            
            innerServices.AddDbContext<HotelDbContext>(
            options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(HotelDbContext)));

            });
            innerServices.AddGraphQLServer().AddQueryType<QueryType<HotelEntity, HotelModel, HotelType>>();
        }
        private static void AddRepositories()
        {
            HotelDbContext hotelDbContext = innerServices.BuildServiceProvider().GetService<HotelDbContext>();
            innerbBuilder.Services.AddScoped<IRepositoryAsync<AdminEntity>, Repository<AdminEntity>>(resolver =>
            {
                return new Repository<AdminEntity>(hotelDbContext, hotelDbContext.Admins);
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<BookingEntity>, Repository<BookingEntity>>(resolver =>
            {
                return new Repository<BookingEntity>(hotelDbContext, hotelDbContext.Bookings);
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<GuestEntity>, Repository<GuestEntity>>(resolver =>
            {
                return new Repository<GuestEntity>(hotelDbContext, hotelDbContext.Guests);
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<HotelEntity>, Repository<HotelEntity>>(resolver =>
            {          
                return new Repository<HotelEntity>(hotelDbContext, hotelDbContext.Hotels);
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<RoomEntity>, Repository<RoomEntity>>(resolver =>
            {
                return new Repository<RoomEntity>(hotelDbContext, hotelDbContext.Rooms);
            });
            innerbBuilder.Services.AddScoped<IRepositoryAsync<RoomTypeEntity>, Repository<RoomTypeEntity>>(resolver =>
            {
                return new Repository<RoomTypeEntity>(hotelDbContext, hotelDbContext.RoomTypes);
            });
        }
        private static void AddRepositoryServices()
        {
            innerServices.AddScoped<IRepositoryServiceAsync<AdminEntity, AdminModel>, RepositoryService<AdminEntity, AdminModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<BookingEntity, BookingModel>, RepositoryService<BookingEntity, BookingModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<GuestEntity, GuestModel>, RepositoryService<GuestEntity, GuestModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<HotelEntity, HotelModel>, RepositoryService<HotelEntity, HotelModel>>();          
            innerServices.AddScoped<IRepositoryServiceAsync<RoomEntity, RoomModel>, RepositoryService<RoomEntity, RoomModel>>();
            innerServices.AddScoped<IRepositoryServiceAsync<RoomTypeEntity, RoomTypeModel>, RepositoryService<RoomTypeEntity, RoomTypeModel>>();
        }
    }
}
