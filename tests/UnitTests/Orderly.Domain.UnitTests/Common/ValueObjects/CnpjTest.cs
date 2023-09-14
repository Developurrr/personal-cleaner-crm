using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CnpjTest
{
    [Theory]
    [MemberData(nameof(CnpjGenerator.CreateCnpjs), MemberType = typeof(CnpjGenerator))]
    public void GivenValidInput_WhenCreatingCnpj_ThenShouldInstantiateCnpj(
        Cnpj cnpj
    )
    {
        // Act
        var newCnpj = Cnpj.Create(cnpj.Value);

        // Assert
        CnpjAssertion.AssertCnpj(cnpj, newCnpj);
    }


    [Theory]
    [MemberData(nameof(CnpjGenerator.CreateInvalidCnpjValues), MemberType = typeof(CnpjGenerator))]
    public void GivenInvalidCnpj_WhenCreatingCnpj_ThenShouldThrowEntityValidationException(
        string invalidCnpj
    )
    {
        // Arrange
        void Action()
        {
            _ = Cnpj.Create(invalidCnpj);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CnpjAssertion.AssertCnpjException(exception!);
    }
}