using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GracefulShutdown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(AddHostedServices);
        }

        private static void AddHostedServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddHostedService<ExampleHostedService>();
            services.AddHostedService<TimeWriterService>();
        }
    }
}
