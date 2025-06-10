using Erdmier.DomainCore.Models;

namespace Erdmier.DomainCore.Tests.Models.SimpleValueObjects;

public sealed class UnitedStatesPhoneNumber : ValueObject
{
    public UnitedStatesPhoneNumber(string areaCode, string localExchange, string subscriberNumber)
    {
        AreaCode         = areaCode;
        LocalExchange    = localExchange;
        SubscriberNumber = subscriberNumber;
    }

    public string AreaCode { get; }

    public string LocalExchange { get; }

    public string SubscriberNumber { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AreaCode;

        yield return LocalExchange;

        yield return SubscriberNumber;
    }
}
