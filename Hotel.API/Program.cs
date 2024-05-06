using System.Diagnostics;
using System.Text.Json.Serialization;
using Hotel.Data;
using Hotel.Data.Configurations;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
public class Program
{
    private static void Main(string[] args)
    {                      
        WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
        ConfigurationManager configuration = builder.Configuration;         
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<HotelDbContext>(
            options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(HotelDbContext)));
            });     
        builder.Services.AddScoped<IRepository, Repository<BookingEntity>>();
       

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.MapControllers();     
        
        app.Run();        
    }  
}