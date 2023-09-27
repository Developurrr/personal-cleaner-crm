using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Shipping;

public sealed class ShippingAssertion
{
    public static void AssertShipping(
        Domain.Shipping.Shipping expected,
        Domain.Shipping.Shipping actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.Equal(expected.Cnpj, actual.Cnpj);
        Assert.Equal(expected.CorporateName, actual.CorporateName);
        Assert.Equal(expected.TaxId, actual.TaxId);
        Assert.Equal(expected.TradeName, actual.TradeName);
        Assert.Equal(expected.Segment, actual.Segment);
    }
}
