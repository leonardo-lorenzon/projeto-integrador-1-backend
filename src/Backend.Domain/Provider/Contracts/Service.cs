

namespace Backend.Domain.Provider.Contracts;

public class Service
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string City { get; set; } // City where the service is offered
    public string State { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Service(
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
