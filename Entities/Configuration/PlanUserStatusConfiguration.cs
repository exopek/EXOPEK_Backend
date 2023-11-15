using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXOPEK_Backend.Entities.Configuration;

public class PlanUserStatusConfiguration : IEntityTypeConfiguration<PlanUserStatus>
{
    public void Configure(EntityTypeBuilder<PlanUserStatus> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.CurrentPhase)
            .HasDefaultValue(PhaseType.Phase1)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (PhaseType)Enum.Parse(typeof(PhaseType), adt));
        
        builder
            .Property(c => c.Status)
            .HasDefaultValue(StatusType.Inactive)
            .HasConversion<string>(
                adt => adt.ToString(),
                adt => (StatusType)Enum.Parse(typeof(StatusType), adt));
    }
}