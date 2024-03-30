using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.services;
using Backend.Domain.Environment;
using Backend.UnitTest.Builders;
using Backend.UnitTest.doubles.fakers;

namespace Backend.UnitTest.factories;

public class AuthenticationServiceFactory
{
    private InMemoryCredentialRepository CredentialRepository { get; }
    private InMemoryAuthenticationRepository AuthenticationRepository { get; }
    private EnvironmentVariables _environmentVariables;

    public AuthenticationServiceFactory()
    {
        CredentialRepository = new InMemoryCredentialRepository();
        AuthenticationRepository = new InMemoryAuthenticationRepository();
        _environmentVariables = new EnvironmentVariablesBuilder().Build();
    }

    public AuthenticationService Build()
    {
        return new AuthenticationService(CredentialRepository, AuthenticationRepository, _environmentVariables);
    }

    public TokenEntity? GetTokenByUserId(Guid userId)
    {
        return AuthenticationRepository.GetTokenByUserId(userId);
    }

    public void SetCredential(string email, Guid userId, string hashedPassword)
    {
        var authCredential = new AuthCredential(userId, hashedPassword);

        CredentialRepository.SetAuthCredential(email, authCredential);
    }

    public void SetEnvironmentVariables(EnvironmentVariables environmentVariables)
    {
        _environmentVariables = environmentVariables;
    }
}
