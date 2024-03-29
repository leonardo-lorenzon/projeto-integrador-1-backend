using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Models;

[PrimaryKey(nameof(Email))]
public class CredentialModel
{
    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string HashedPassword { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CredentialModel(string email, string hashedPassword, DateTime createdAt, DateTime updatedAt)
    {
        Email = email;
        HashedPassword = hashedPassword;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
