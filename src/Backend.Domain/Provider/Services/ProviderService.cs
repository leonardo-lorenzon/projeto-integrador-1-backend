using Backend.Domain.Provider.Contracts;
using Backend.Domain.Provider.Repositories;

namespace Backend.Domain.Provider.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderServiceRepository _providerServiceRepository;

    public ProviderService(IProviderServiceRepository providerServiceRepository)
    {
        _providerServiceRepository = providerServiceRepository;
    }

    public async Task AddService(ServiceEntity serviceEntity)
    {
        await _providerServiceRepository.AddService(serviceEntity);
    }

    public async Task<IEnumerable<ServiceEntity>> ListServices(SearchService searchService)
    {
        var services = await _providerServiceRepository.ListServices(searchService);

        return services;
    }
}
