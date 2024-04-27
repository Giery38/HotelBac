using System.Diagnostics;
using System.Text.Json.Serialization;
using Hotel.DataAccess.Postgres;
using Hotel.DataAccess.Postgres.Configurations;
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