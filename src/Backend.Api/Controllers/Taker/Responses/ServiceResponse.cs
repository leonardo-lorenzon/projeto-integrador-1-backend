namespace Backend.Api.Controllers.Taker.Responses;

public class ServiceResponse
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public ServiceResponse(
        Guid id,
        Guid accountId,
        string type,
        string description,
        string city,
        string state,
        string country
    )
    {
        Id = id.ToString();
        AccountId = accountId.ToString();
        Type = type;
        Description = description;
        City = city;
        State = state;
        Country = country;
    }
}
