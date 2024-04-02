using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext.Models;

[PrimaryKey(nameof(UserId))]
[Index(nameof(Email), IsUnique = true)]
public class UserModel
{
    public Guid UserId { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Surname { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserModel(
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
