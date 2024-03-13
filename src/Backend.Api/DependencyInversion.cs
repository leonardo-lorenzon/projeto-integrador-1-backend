using Backend.Domain.User.Repositories;
using Backend.Domain.User.Services;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api;

public class DependencyInversion
{
    private readonly IServiceCollection _serviceCollection;
    private readonly ConfigurationManager _configuration;

    public DependencyInversion(IServiceCollection serviceCollection, ConfigurationManager configuration)
    {
        _serviceCollection = serviceCollection;
        _configuration = configuration;
    }

    public void AddServices()
    {
        _serviceCollection.AddTransient<IUserRegisterService, UserRegisterService>();
    }

    public void AddRepositories()
    {
        _serviceCollection.AddTransient<IUserRepository, UserRepository>();
    }

    public void AddPostgreSqlContext()
    {
        _serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
        );
    }
}
