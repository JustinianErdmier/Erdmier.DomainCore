using Erdmier.DomainCore.Tests.Models.Models.SimpleValueObjects;

namespace Erdmier.DomainCore.Tests.Models.Constants;

public static partial class Constants
{
    public static class ValueObjects
    {
        public static UnitedStatesPhoneNumber TestPhoneNumber1 { get; } = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");

        public static UnitedStatesPhoneNumber TestPhoneNumber2 { get; } = new(areaCode: "502", localExchange: "390", subscriberNumber: "4810");
    }
}
