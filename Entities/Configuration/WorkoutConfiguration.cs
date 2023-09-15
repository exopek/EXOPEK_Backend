using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(l => l.Images);

        builder
            .HasMany(v => v.WorkoutExercises)
            .WithOne(wv => wv.Workout);

        builder
            .HasMany(v => v.WorkoutUserComments)
            .WithOne(wv => wv.Workout);
        
        builder
            .HasMany(v => v.WorkoutUserLikes)
            .WithOne(wv => wv.Workout);
        
        builder
            .HasMany(v => v.WorkoutUserCompletes)
            .WithOne(wv => wv.Workout);
    }
}