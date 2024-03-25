using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(v => v.PlanWorkouts)
            .WithOne(wv => wv.Plan);
        
        builder
            .HasMany(v => v.PlanUserStatus)
            .WithOne(wv => wv.Plan);
        
        builder
            .Property(c => c.Difficulty)
            .HasDefaultValue(DifficultyType.None)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (DifficultyType)Enum.Parse(typeof(DifficultyType), adt));

        builder
            .Property(c => c.Target)
            .HasDefaultValue(TargetType.None)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (TargetType)Enum.Parse(typeof(TargetType), adt));
    }
}