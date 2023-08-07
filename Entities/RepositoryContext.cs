using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Entities;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }
    // Für initalen Seed
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
    }*/
    
    public DbSet<Workout> Workouts { get; set; }
}



