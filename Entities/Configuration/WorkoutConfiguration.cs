using EXOPEK_Backend.Entities.BaseModels;
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
            .HasMany(v => v.Videos);


    }
}