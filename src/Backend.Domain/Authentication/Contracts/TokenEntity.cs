using JWT.Algorithms;
using JWT.Builder;

namespace Backend.Domain.Authentication.Contracts;

public class TokenEntity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public TokenEntity(
        Guid userId,
        string token,
        string refreshToken,
        DateTime createdAt
        )
    {
        UserId = userId;
        Token = token;
        RefreshToken = refreshToken;
        CreatedAt = createdAt;
    }

    public static TokenEntity Build(
        Guid userId,
        int tokenExpirationHours,
        int refreshTokenExpirationDays,
        string key
        )
    {
        var tokenExpiresAt = DateTimeOffset.UtcNow.AddHours(tokenExpirationHours);
        var refreshTokenExpiresAt = DateTimeOffset.UtcNow.AddDays(refreshTokenExpirationDays);

        var token = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(key)
            .AddClaim("exp", tokenExpiresAt.ToUnixTimeSeconds())
            .AddClaim("userId", userId.ToString())
            .Encode();

        var refreshToken = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(key)
            .AddClaim("exp", refreshTokenExpiresAt.ToUnixTimeSeconds())
            .AddClaim("userId", userId.ToString())
            .Encode();

        return new TokenEntity(
            userId,
            token,
            refreshToken,
            DateTime.UtcNow
        );
    }
}
