using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.Repositories;
using Backend.Domain.Errors;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.DatabaseContext.Models;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Authentication.Repositories;

public class PostgresAuthenticationRepository : IAuthenticationRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PostgresAuthenticationRepository> _logger;

    public PostgresAuthenticationRepository(
        ApplicationDbContext dbContext,
        ILogger<PostgresAuthenticationRepository> logger
        )
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task CreateToken(TokenEntity token)
    {
        var tokenModel = new TokenModel(
            token.UserId,
            token.Token,
            token.RefreshToken,
            token.CreatedAt
            );

        try
        {
            await _dbContext.Tokens.AddAsync(tokenModel);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                "PostgreSQL error while creating token: {Message}",
                exception.ToString()
            );

            throw new FailToCreateTokenException();
        }
    }
}
