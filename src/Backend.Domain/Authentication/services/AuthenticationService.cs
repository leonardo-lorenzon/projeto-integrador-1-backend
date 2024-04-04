using System.Security.Authentication;
using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.Repositories;
using Backend.Domain.Environment;

namespace Backend.Domain.Authentication.services;

public class AuthenticationService : IAuthenticationService
{
    private readonly ICredentialRepository _credentialRepository;
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly EnvironmentVariables _environmentVariables;

    public AuthenticationService(
        ICredentialRepository credentialRepository,
        IAuthenticationRepository authenticationRepository,
        EnvironmentVariables environmentVariables
        )
    {
        _credentialRepository = credentialRepository;
        _authenticationRepository = authenticationRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<TokenEntity> Login(LoginCredential credential)
    {
        var authCredential = await _credentialRepository.GetAuthCredentialByEmail(credential.Email);

        if (authCredential is null || credential.VerifyPasswordAgainstHash(authCredential.HashedPassword) is not true)
        {
            throw new InvalidCredentialException();
        }

        var token = TokenEntity.Build(
            authCredential.UserId,
            _environmentVariables.TokenExpirationHours,
            _environmentVariables.RefreshTokenExpirationDays,
            _environmentVariables.TokenSecretKey);

        await _authenticationRepository.CreateToken(token);

        return token;
    }
}
