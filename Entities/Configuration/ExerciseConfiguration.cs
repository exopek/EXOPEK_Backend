using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder
            .HasMany(v => v.WorkoutExercises)
            .WithOne(wv => wv.Exercise);

        builder
            .Property(c => c.Difficulty)
            .HasDefaultValue(DifficultyType.None)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (DifficultyType)Enum.Parse(typeof(DifficultyType), adt));

        builder
            .Property(c => c.Category)
            .HasDefaultValue(CategoryType.None)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (CategoryType)Enum.Parse(typeof(CategoryType), adt));
    }
}