using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
