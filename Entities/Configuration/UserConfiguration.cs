using EXOPEK_Backend.Entities.Enums;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(v => v.WorkoutUserComments)
            .WithOne(wv => wv.User);
        
        builder
            .HasMany(v => v.WorkoutUserLikes)
            .WithOne(wv => wv.User);
        
        builder
            .HasMany(v => v.WorkoutUserCompletes)
            .WithOne(wv => wv.User);
        
        builder
            .HasMany(v => v.PlanUserStatus)
            .WithOne(wv => wv.User);
        
        builder
            .Property(c => c.SportType)
            .HasDefaultValue(SportType.None)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (SportType)Enum.Parse(typeof(SportType), adt));
    }
}