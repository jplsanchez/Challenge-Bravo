using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces.Repositories;
using CB.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Currency>, Repository<Currency>>();
            return services;
        }
    }
}
