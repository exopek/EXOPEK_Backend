using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;


public class PlanWorkoutConfiguration : IEntityTypeConfiguration<PlanWorkout>
{
    public void Configure(EntityTypeBuilder<PlanWorkout> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(v => v.Plan)
            .WithMany(wv => wv.PlanWorkouts)
            .HasForeignKey(v => v.PlanId);

        builder
            .HasOne(v => v.Workout)
            .WithMany(wv => wv.PlanWorkouts)
            .HasForeignKey(v => v.WorkoutId);
        
        builder 
            .Property(c => c.PhaseType)
            .HasDefaultValue(PhaseType.Phase1)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (PhaseType)Enum.Parse(typeof(PhaseType), adt));
    }
}
