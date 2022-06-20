using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces;
using CB.Core.Service.Abstractions;
using CB.Core.Service.Services;
using CB.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Currency>, Repository<Currency>>();
            services.AddScoped<IConversionService, ConversionService>();
            return services;
        }
    }
}
