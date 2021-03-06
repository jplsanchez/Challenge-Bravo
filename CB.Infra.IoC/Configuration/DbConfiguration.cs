using CB.Core.Domain.Interfaces;
using CB.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC.Configuration
{
    internal static class DbConfiguration
    {
        public static IServiceCollection ConfigureDb(this IServiceCollection services, IGlobalSettings settings)
        {
            services.AddDbContext<MainDbContext>(builder =>
            {
                builder.UseNpgsql(settings.PostgresConnStr);
            });
            return services;
        }
    }
}
