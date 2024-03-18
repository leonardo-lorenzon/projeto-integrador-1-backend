using Backend.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
