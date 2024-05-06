using Backend.Infrastructure.DatabaseContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<AccountModel> Accounts { get; set; }
    public DbSet<CredentialModel> Credentials { get; set; }
    public DbSet<TokenModel> Tokens { get; set; }
    public DbSet<ServiceModel> Services { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
