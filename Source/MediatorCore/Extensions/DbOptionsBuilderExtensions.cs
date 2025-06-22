using Microsoft.EntityFrameworkCore;

namespace Erdmier.DomainCore.MediatorCore;

public static class DbOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseDomainMediatorCore(this DbContextOptionsBuilder optionsBuilder, PublishDomainEventsInterceptor interceptor)
    {
        optionsBuilder.AddInterceptors(interceptor);

        return optionsBuilder;
    }
}
