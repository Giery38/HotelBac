using System.Diagnostics;
using System.Text.Json.Serialization;
using Hotel.Core.DataAccess;
using Hotel.Core.Repositories;
using Hotel.DataAccess.Postgres;
using Hotel.DataAccess.Postgres.Configurations;
using Hotel.DataAccess.Postgres.Models;
using Hotel.DataAccess.Postgres.Repositories.Hotel;
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
        builder.Services.AddScoped<IRepository, HotelRepository>();
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