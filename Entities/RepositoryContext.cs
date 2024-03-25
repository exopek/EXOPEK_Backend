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
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new PlanConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new PlanUserStatusConfiguration());
        modelBuilder.ApplyConfiguration(new PlanWorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutExerciseConfiguration());
    }
    
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutUserLikes> WorkoutUserLikes { get; set; }
    public DbSet<WorkoutUserComments> WorkoutUserComments { get; set; }
    public DbSet<WorkoutUserCompletes> WorkoutUserCompletes { get; set; }
    public DbSet<PlanUserStatus> PlanUserStatus { get; set; }
}



