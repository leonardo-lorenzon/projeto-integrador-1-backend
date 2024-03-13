using Backend.Domain.User.contracts;

namespace Backend.UnitTest.TestSubclasses;

public class UserEntityTestSubclass : UserEntity
{
    public UserEntityTestSubclass(Guid userId, string name, string surname, string email, DateTime createdAt, DateTime updatedAt) : base(userId, name, surname, email, createdAt, updatedAt)
    {
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }
}
