namespace Backend.Domain.User.contracts;

public class Account
{
    public Guid AccountId { get; }
    public Guid UserId { get; }
    public AccountType Type { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; set; }

    public Account(Guid accountId, Guid userId, AccountType type, DateTime createdAt, DateTime updatedAt)
    {
        AccountId = accountId;
        UserId = userId;
        Type = type;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public bool IsTaker()
    {
        return Type == AccountType.Taker;
    }
}
