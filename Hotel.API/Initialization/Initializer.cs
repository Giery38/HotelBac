using HotChocolate.Execution.Configuration;
using Hotel.API.GraphQL.Models.Hotel;
using Hotel.API.GraphQL.Queries.Data.Common;
using Hotel.Application.Services.Data;
using Hotel.Application.Services.Data.Common;
using Hotel.Core.Models;
using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Common;
using Hotel.Core.Models.Users.Guests;
using Hotel.Core.Models.Users.Staff;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
            innerServices.AddDbContext<HotelDbContext>(
            options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(HotelDbContext)));
            });
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
            IRequestExecutorBuilder RequestExecutorBuilder = innerServices.AddGraphQLServer();
            RequestExecutorBuilder.AddQueryType<Test<BookingEntity,BookingModel,BookingQL>>().AddFiltering().AddProjections().AddSorting();        
        } 

        private static void AddRepositories()
        {
            HotelDbContext hotelDbContext = innerServices.BuildServiceProvider().GetService<HotelDbContext>();
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Bookings);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Guests);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Services);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.ServiceTypes);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Feedbacks);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.Staff);
            innerServices.AddRepository(hotelDbContext, hotelDbContext.PositionTypes);
        }
        private static void AddRepository<TEntity>(this IServiceCollection services, HotelDbContext hotelDbContext, DbSet<TEntity> dbSet) where TEntity : Entity
        {
            innerServices.AddScoped<IRepositoryAsync<TEntity>, Repository<TEntity>>(resolver =>
            {
                return new Repository<TEntity>(hotelDbContext, dbSet);
            });
        }

        private static void AddRepositoryServices()
        {
            innerServices.AddScoped<IRepositoryServicesCollection, RepositoryServicesCollection>();
            IRepositoryServicesCollection collection = innerServices.BuildServiceProvider().GetService<IRepositoryServicesCollection>();
            innerServices.AddRepositoryService<BookingEntity, BookingModel>(collection);
            innerServices.AddRepositoryService<GuestEntity, GuestModel>(collection);
            innerServices.AddRepositoryService<ServiceEntity, ServiceModel>(collection);
            innerServices.AddRepositoryService<ServiceTypeEntity, ServiceTypeModel>(collection);
            innerServices.AddRepositoryService<UserFeedbackEntity, UserFeedbackModel>(collection);
            innerServices.AddRepositoryService<StaffEntity, StaffModel>(collection);
            innerServices.AddRepositoryService<PositionTypeEntity, PositionTypeModel>(collection);
        }
        private static void AddRepositoryService<TEntity, TModel>(this IServiceCollection services, IRepositoryServicesCollection collection)
            where TEntity : Entity
            where TModel : Model
        {            
            services.AddScoped<IRepositoryServiceAsync<TEntity, TModel>, RepositoryService<TEntity, TModel>>();
            IRepositoryServiceAsync<TEntity, TModel> item =  innerServices.BuildServiceProvider().GetService<IRepositoryServiceAsync<TEntity, TModel>>();
            collection.Add(item);
        }
    }
}