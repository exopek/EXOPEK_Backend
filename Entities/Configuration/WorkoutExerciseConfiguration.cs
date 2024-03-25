using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(l => l.Workout)
            .WithMany(v => v.WorkoutExercises)
            .HasForeignKey(l => l.WorkoutId);

        builder
            .HasOne(l => l.Exercise)
            .WithMany(v => v.WorkoutExercises)
            .HasForeignKey(l => l.ExerciseId);
        
        builder
            .Property(c => c.Reps)
            .HasDefaultValue(0);

        builder
            .Property(c => c.StageType)
            .HasDefaultValue(StageType.Main)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (StageType)Enum.Parse(typeof(StageType), adt));

    }
}