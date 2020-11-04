using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DummyWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //   .UseKestrel(x => x.AllowSynchronousIO = true)
            //   .UseUrls("http://*:5050")
            //   .UseContentRoot(Directory.GetCurrentDirectory())
            //   .UseStartup<Startup>()
            //   .Build();
            //host.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
