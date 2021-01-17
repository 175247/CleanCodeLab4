using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Lab4MySql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().CreateDatabase<CalculationDbContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://0.0.0.0:80", "http://0.0.0.0:5000");
                });
    }
}
