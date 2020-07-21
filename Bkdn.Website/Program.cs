using Bkdn.Website.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Bkdn.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(_ => {})
                .ConfigureWebHostDefaults(UseStartup);

        private static void UseStartup(IWebHostBuilder webBuilder) => webBuilder.UseStartup<Startup>();
    }
}