using EXOPEK_Backend.Entities.Configuration;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Entities;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }
    // Für initalen Seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
    
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Plan> Plans { get; set; }
}



