using System;
using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace CLI
{
    class Program
    {
        private static IServiceProvider provider { get; set; }
        static void Main(string[] args)
        {
            RegisterServices();
            provider.CreateScope().ServiceProvider.GetRequiredService<ConsoleFunctions>().Initialize();
            Environment.Exit(0);
        }
        private static void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IOrganizationService, OrganizationService>();
            services.AddSingleton<OrganizationFunctions>();
            services.AddSingleton<ConsoleFunctions>();
            provider = services.BuildServiceProvider(true);
        }
    }
}
