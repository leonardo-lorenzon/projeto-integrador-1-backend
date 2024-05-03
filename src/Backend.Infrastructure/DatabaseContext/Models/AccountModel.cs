using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext.Models;

[PrimaryKey(nameof(AccountId))]
public class AccountModel
{
    public Guid AccountId { get; set; }
    public Guid UserId { get; set; }
    [Column(TypeName = "varchar(15)")]
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public AccountModel(
        Guid accountId,
        Guid userId,
        string type,
        DateTime createdAt,
        DateTime updatedAt
        )
    {
        AccountId = accountId;
        UserId = userId;
        Type = type;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
