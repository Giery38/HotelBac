using Hotel.API.Initialization;
using Hotel.Application.Services.Data;

public class Program
{
    private static void Main(string[] args)
    {
        Test test = new Test();

        WebApplicationBuilder builder = Initializer.Initialize(args);

        WebApplication app = Initializer.Startup(builder);
    }
}
