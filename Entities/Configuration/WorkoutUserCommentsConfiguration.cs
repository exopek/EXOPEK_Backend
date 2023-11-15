using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class WorkoutUserCommentsConfiguration : IEntityTypeConfiguration<WorkoutUserComments>
{
    public void Configure(EntityTypeBuilder<WorkoutUserComments> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(l => l.User)
            .WithMany(l => l.WorkoutUserComments)
            .HasForeignKey(l => l.User.Id);

        builder
            .HasOne(l => l.Workout)
            .WithMany(l => l.WorkoutUserComments)
            .HasForeignKey(l => l.WorkoutId);
    }
}