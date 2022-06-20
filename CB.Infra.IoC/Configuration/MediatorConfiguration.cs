using CB.Core.Service.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CB.Infra.IoC.Configuration
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCurrencyHandler));
            services.AddMediatR(typeof(EditCurrencyHandler));
            services.AddMediatR(typeof(DeleteCurrencyHandler));

            return services;
        }
    }
}
