using Backend.Domain.Provider.Contracts;

namespace Backend.Domain.Provider.Repositories;

public interface IProviderServiceRepository
{
    public Task AddService(Service service);
}
