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
    }
}