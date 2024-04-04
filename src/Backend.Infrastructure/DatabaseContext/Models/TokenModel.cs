using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext.Models;

[PrimaryKey(nameof(Token))]
[Index(nameof(UserId), IsUnique = false)]
[Index(nameof(RefreshToken), IsUnique = false)]
public class TokenModel
{
    public string Token { get; set; }

    public Guid UserId { get; set; }

    public string RefreshToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public TokenModel(Guid userId, string token, string refreshToken, DateTime createdAt)
    {
        UserId = userId;
        Token = token;
        RefreshToken = refreshToken;
        CreatedAt = createdAt;
    }
}
