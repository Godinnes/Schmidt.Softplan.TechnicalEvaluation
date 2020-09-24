using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Schmidt.Softplan.TechnicalEvaluation.Bootstrap;
using Schmidt.Softplan.TechnicalEvaluation.Data.Seeder;

namespace Schmidt.Softplan.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Seed().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
