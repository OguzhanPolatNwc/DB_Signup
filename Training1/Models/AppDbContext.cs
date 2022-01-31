using Microsoft.EntityFrameworkCore;

namespace Training1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<RegisterModel> Registers { get; set; }
}