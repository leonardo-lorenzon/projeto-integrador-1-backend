using Backend.Domain.Authentication.Contracts;

namespace Backend.Domain.Authentication.services;

public interface IAuthenticationService
{
    public Task<TokenEntity> Login(LoginCredential credential);
}
