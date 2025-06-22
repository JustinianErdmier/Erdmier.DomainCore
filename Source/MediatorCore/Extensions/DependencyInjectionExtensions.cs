using Microsoft.Extensions.DependencyInjection;

namespace Erdmier.DomainCore.MediatorCore;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDomainMediatorCore(this IServiceCollection services)
    {
        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }
}
