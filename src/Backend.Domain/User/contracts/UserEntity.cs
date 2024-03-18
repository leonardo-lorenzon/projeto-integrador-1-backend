namespace Backend.Domain.User.contracts;

public class UserEntity
{
    public Guid UserId { get; }
    public string Name { get; }
    public string Surname { get; }
    public string Email { get; protected set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; set; }

    public UserEntity(
        Guid userId,
        string name,
        string surname,
        string email,
        DateTime createdAt,
        DateTime updatedAt
        )
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Email = email;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
