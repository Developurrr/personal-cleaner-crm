using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public class SalesConsultantAssertion
{
    public static void AssertSalesConsultant(
        Domain.SalesConsultant.SalesConsultant expected,
        Domain.SalesConsultant.SalesConsultant actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.NotEqual(actual.Id.Value, default);
        Assert.Equal(expected.Cpf, actual.Cpf);
        Assert.Equal(expected.Address, actual.Address);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Email, actual.Email);
        Assert.Equal(expected.Landline, actual.Landline);
        Assert.Equal(expected.Mobile, actual.Mobile);
        Assert.NotEqual(actual.CreatedAt, default);
    }
    
    
    public static void AssertSalesConsultantException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);
    }
}