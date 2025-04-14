using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rocs.Domain.Entities;

namespace Rocs.Infraestructure.Configuration
{
    public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ActivityType");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasData(
                ActivityType.Create(1, "Build Component", 2, 1),
                ActivityType.Create(2, "Build Machine", 4, 999));
        }
    }
}
