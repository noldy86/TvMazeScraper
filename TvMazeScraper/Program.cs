using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TvMazeScraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Scrape();
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void Scrape()
        {

        }
    }
}
