using CB.Core.Domain.Interfaces;
using CB.Infra.IoC.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));

            GlobalSettings settings = new(configuration);
            services.AddSingleton<IGlobalSettings>(settings);

            services.ResolveDependencies();
            services.ConfigureDb(settings);
            services.ConfigureMediatR();
            services.ConfigureAuthentication(settings);

            return services;
        }

    }

}
