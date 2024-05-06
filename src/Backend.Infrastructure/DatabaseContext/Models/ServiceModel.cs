using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext.Models;

[PrimaryKey(nameof(Id))]
[Index(nameof(Type), IsUnique = false)]
[Index(nameof(City), IsUnique = false)]
public class ServiceModel
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    [Column(TypeName = "varchar(30)")]
    public string Type { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "varchar(40)")]
    public string City { get; set; }
    [Column(TypeName = "varchar(30)")]
    public string State { get; set; }
    [Column(TypeName = "varchar(20)")]
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ServiceModel(
        Guid id,
        Guid accountId,
        string type,
        string description,
        string city,
        string state,
        string country,
        DateTime createdAt,
        DateTime updatedAt
        )
    {
        Id = id;
        AccountId = accountId;
        Type = type;
        Description = description;
        City = city;
        State = state;
        Country = country;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
