using System.ComponentModel.DataAnnotations;
using Backend.Domain.Provider.Contracts;

namespace Backend.Api.Controllers.Provider.Requests;

public class ServiceRequest
{
    [Required]
    public string Type { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Country { get; set; }

    public ServiceRequest(string type, string description, string city, string state, string country)
    {
        Type = type;
        Description = description;
        City = city;
        State = state;
        Country = country;
    }

    public ServiceEntity ToDomain(string accountId)
    {
        return new ServiceEntity(
                Guid.NewGuid(),
                Guid.Parse(accountId),
                Type,
                Description,
                City,
                State,
                Country,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
    }
}
