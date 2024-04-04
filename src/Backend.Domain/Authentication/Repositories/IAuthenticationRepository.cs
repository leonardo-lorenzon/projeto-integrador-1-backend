using Backend.Domain.Authentication.Contracts;

namespace Backend.Domain.Authentication.Repositories;

public interface IAuthenticationRepository
{
    public Task CreateToken(TokenEntity token);
}
