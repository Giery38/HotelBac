using Hotel.API.Initialization;
using Hotel.Core.Models;
public class Program
{
    private static void Main(string[] args)
    {        
        WebApplicationBuilder builder = Initializer.Initialize(args);

        WebApplication app = Initializer.Startup(builder);        
    }  
}

