using Erdmier.DomainCore.Tests.Models.Models.IDs;

namespace Erdmier.DomainCore.Tests.Models.Constants;

public static partial class Constants
{
    public static class AggregateRootIds
    {
        public static TestAggregateRootId Id1 { get; } = TestAggregateRootId.Create();

        public static TestAggregateRootId Id2 { get; } = TestAggregateRootId.Create();
    }
}
