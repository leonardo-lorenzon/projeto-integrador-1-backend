using Backend.Domain.User.contracts;
using Backend.UnitTest.TestSubclasses;

namespace Backend.UnitTest.Builders;

public class CredentialBuilder
{
    private readonly LoginCredentialTestSubclass _loginCredential;

    public CredentialBuilder()
    {
        _loginCredential = BuildDefault();
    }

    public LoginCredential Build()
    {
        return _loginCredential;
    }

    public CredentialBuilder WithEmail(string email)
    {
        _loginCredential.UpdateEmail(email);

        return this;
    }

    private static LoginCredentialTestSubclass BuildDefault()
    {
        return new LoginCredentialTestSubclass("name@test.com", "pass123");
    }
}
