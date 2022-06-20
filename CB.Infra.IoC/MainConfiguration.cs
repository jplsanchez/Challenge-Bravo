using CB.Infra.IoC.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC
{
    public static class MainConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));

            GlobalSettings settings = new(configuration);
            services.AddSingleton(settings);

            services.ResolveDependencies();
            services.ConfigureDb(settings);

            return services;
        }

    }

}
