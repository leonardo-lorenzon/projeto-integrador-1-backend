using Backend.Domain.Provider.Contracts;

namespace Backend.Domain.Provider.Repositories;

public interface IProviderServiceRepository
{
    public Task AddService(ServiceEntity serviceEntity);
    public Task<IEnumerable<ServiceEntity>> ListServices(SearchService searchService);
}
