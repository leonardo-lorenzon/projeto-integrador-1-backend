using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext.Models;

[PrimaryKey(nameof(UserId))]
public class CredentialModel
{
    public Guid UserId { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string HashedPassword { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CredentialModel(Guid userId, string hashedPassword, DateTime createdAt, DateTime updatedAt)
    {
        UserId = userId;
        HashedPassword = hashedPassword;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
