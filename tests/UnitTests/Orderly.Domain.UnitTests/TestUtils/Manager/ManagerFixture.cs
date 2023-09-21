using Bogus.Extensions.Brazil;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public sealed class ManagerFixture : BaseFixture
{
    private static Domain.Manager.Manager CreateValidManager()
    {
        var cpf = CpfFixture.CreateCpf().Value;
        var address = AddressFixture.CreateAddress();
        var nfeEmail = EmailFixture.CreateEmail().Value;
        var landline = PhoneFixture.CreatePhone().Value;
        var mobile = PhoneFixture.CreatePhone().Value;

        var name = StringFixture.CreateString(
            ManagerValidator.NameMinLength,
            ManagerValidator.NameMaxLength
        );

        return Domain.Manager.Manager.Create(cpf, address.Street, address.Number, address.Complement, address.ZipCode, address.Neighborhood, address.City, address.State, address.Country, name, nfeEmail, landline, mobile);
    }

    public static Domain.Manager.Manager CreateManager(
        Domain.Manager.Manager? manager = null,
        string? name = null
    )
    {
        var lManager = manager ?? CreateValidManager();

        return Domain.Manager.Manager.Create(
            lManager.Cpf.Value,
            lManager.Address.Street,
            lManager.Address.Number,
            lManager.Address.Complement,
            lManager.Address.ZipCode,
            lManager.Address.Neighborhood,
            lManager.Address.City,
            lManager.Address.State,
            lManager.Address.Country,
            name ?? lManager.Name,
            lManager.Email.Value,
            lManager.Landline?.Value,
            lManager.Mobile?.Value
        );
    }

    public static string CreateShortName()
    {
        return StringFixture.CreateString(1, ManagerValidator.NameMinLength - 1);
    }

    public static string CreateLongName()
    {
        return StringFixture.CreateString(ManagerValidator.NameMaxLength + 1, 1_000);
    }
}
