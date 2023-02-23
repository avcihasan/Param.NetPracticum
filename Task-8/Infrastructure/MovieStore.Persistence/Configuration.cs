using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MovieStore.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get {


                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MovieStore.API"));
                configurationManager.AddJsonFile("appsettings.json");

              
                return configurationManager.GetConnectionString("SqlServer");
                
                }
        }
    }
}
