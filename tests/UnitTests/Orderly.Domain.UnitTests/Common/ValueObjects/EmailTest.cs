﻿using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class EmailTest
{
    [Theory]
    [MemberData(nameof(EmailGenerator.CreateEmails), MemberType = typeof(EmailGenerator))]
    public void GivenValidInput_WhenCreatingEmail_ThenShouldInstantiateEmail(
        Email email
    )
    {
        // Act
        var newEmail = Email.Create(email.Value);

        // Assert
        EmailAssertion.AssertEmail(email, newEmail);
    }


    [Theory]
    [MemberData(nameof(EmailGenerator.CreateInvalidEmailAddresses), MemberType = typeof(EmailGenerator))]
    public void GivenInvalidEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationException(
        string invalidEmail
    )
    {
        // Arrange
        void Action()
        {
            _ = Email.Create(invalidEmail);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        EmailAssertion.AssertEmailException(exception!);
    }


    [Theory]
    [MemberData(nameof(StringGenerator.CreateInvalidStrings), MemberType = typeof(StringGenerator))]
    public void GivenInvalidString_WhenCreatingEmail_ThenShouldThrowEntityValidationException(
        string invalidString
    )
    {
        // Arrange
        void Action()
        {
            _ = Email.Create(invalidString);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        EmailAssertion.AssertEmailException(exception!);
    }
}