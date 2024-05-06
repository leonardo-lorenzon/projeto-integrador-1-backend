using Backend.Domain.Provider.Contracts;

namespace Backend.Domain.Provider.Servides;

public interface IProviderService
{
    public Task AddService(Service service);
}
