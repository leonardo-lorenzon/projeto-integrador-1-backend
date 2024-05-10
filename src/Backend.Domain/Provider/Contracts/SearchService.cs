

namespace Backend.Domain.Provider.Contracts;

public class SearchService
{
    public string Type { get; set; }

    public SearchService(
        string type
        )
    {
        Type = type;
    }
}
