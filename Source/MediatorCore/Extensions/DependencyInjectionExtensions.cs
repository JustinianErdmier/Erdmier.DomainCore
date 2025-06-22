using Microsoft.Extensions.DependencyInjection;

namespace Erdmier.DomainCore.MediatorCore;

/// <summary>Provides extension methods for registering dependencies related to Domain Core Mediator's functionality.</summary>
[ UsedImplicitly ]
public static class DependencyInjectionExtensions
{
    /// <summary>Registers the necessary services and dependencies to support Domain Core Mediator functionality.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to which the domain mediator services will be added.</param>
    /// <returns>The <see cref="IServiceCollection" /> instance with the domain mediator services registered.</returns>
    [ UsedImplicitly ]
    public static IServiceCollection AddDomainMediatorCore(this IServiceCollection services)
    {
        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }
}
