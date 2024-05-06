using Backend.Domain.Provider.Contracts;
using Backend.Domain.Provider.Repositories;

namespace Backend.Domain.Provider.Servides;

public class ProviderService : IProviderService
{
    private readonly IProviderServiceRepository _providerServiceRepository;

    public ProviderService(IProviderServiceRepository providerServiceRepository)
    {
        _providerServiceRepository = providerServiceRepository;
    }

    public async Task AddService(Service service)
    {
        await _providerServiceRepository.AddService(service);
    }
}
