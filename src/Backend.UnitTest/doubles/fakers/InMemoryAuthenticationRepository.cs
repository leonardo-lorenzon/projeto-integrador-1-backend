using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.Repositories;

namespace Backend.UnitTest.doubles.fakers;

public class InMemoryAuthenticationRepository : IAuthenticationRepository
{
    private readonly Dictionary<Guid, TokenEntity> _tokens = new Dictionary<Guid, TokenEntity>();

    public Task CreateToken(TokenEntity token)
    {
        _tokens.Add(token.UserId, token);

        return Task.CompletedTask;
    }

    // only for test purposes
    public TokenEntity? GetTokenByUserId(Guid userId)
    {
        _tokens.TryGetValue(userId, out var token);

        return token;
    }
}
