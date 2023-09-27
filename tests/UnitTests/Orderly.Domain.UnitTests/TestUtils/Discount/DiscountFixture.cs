using Orderly.Domain.Order.Validators;

namespace Orderly.Domain.UnitTests.TestUtils.Discount;

public sealed class DiscountFixture : BaseFixture
{
    private static Domain.Order.ValueObjects.Discount CreateValidDiscount()
    {
        var value = decimal.Parse(Faker.Commerce.Price(DiscountValidatorConfig.DiscountMin, DiscountValidatorConfig.DiscountMax));

        return Domain.Order.ValueObjects.Discount.Create(value);
    }
    
    public static Domain.Order.ValueObjects.Discount CreateDiscount(
        Domain.Order.ValueObjects.Discount? discount = null,
        decimal? value = null
    )
    {
        var lDiscount = discount ?? CreateValidDiscount();

        return Domain.Order.ValueObjects.Discount.Create(value ?? lDiscount.Value);
    }
    
    public static decimal CreateBellowMinDiscount()
    {
        return decimal.Parse(Faker.Commerce.Price(decimal.MinValue, DiscountValidatorConfig.DiscountMin));
    }
    
    public static decimal CreateAboveMaxDiscount()
    {
        return decimal.Parse(Faker.Commerce.Price(DiscountValidatorConfig.DiscountMax, decimal.MaxValue));
    }
}