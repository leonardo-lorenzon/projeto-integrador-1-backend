using Backend.Domain.Provider.Contracts;

namespace Backend.Domain.Provider.Services;

public interface IProviderService
{
    public Task AddService(ServiceEntity serviceEntity);

    public Task<IEnumerable<ServiceEntity>> ListServices(SearchService searchService);
}
