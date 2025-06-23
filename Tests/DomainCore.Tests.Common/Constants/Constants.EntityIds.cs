using Erdmier.DomainCore.Tests.Models.Models.IDs;

namespace Erdmier.DomainCore.Tests.Models.Constants;

public static partial class Constants
{
    public static class EntityIds
    {
        public static TestEntityId Id1 { get; } = TestEntityId.Create();

        public static TestEntityId Id2 { get; } = TestEntityId.Create();
    }
}
