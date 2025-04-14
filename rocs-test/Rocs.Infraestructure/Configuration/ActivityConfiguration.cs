using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rocs.Domain.Entities;

namespace Rocs.Infraestructure.Configuration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity");

            builder.Property(e => e.Id);
            builder.Property(e => e.EndDate).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.StartDate).HasColumnType("datetime");
            builder.Property(e => e.TypeId).HasColumnName("TypeID");

            builder.HasOne(d => d.Type).WithMany(p => p.Activities)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_ActivityType");

            var activities = new[] {
                Activity.Create(1,
                    "Build component 1",
                    new DateTime(2025, 4, 13, 13, 00, 0),
                    new DateTime(2025, 4, 13, 17, 00, 0),
                1),
                Activity.Create(2,
                    "Build component 2",
                    new DateTime(2025, 4, 13, 19, 01, 0),
                    new DateTime(2025, 4, 13, 21, 00, 0),
                1),
                Activity.Create(3,
                    "Build machine 1",
                    new DateTime(2025, 4, 14, 06, 10, 0),
                    new DateTime(2025, 4, 14, 10, 00, 0),
                2),
                Activity.Create(4,
                    "Build machine 2",
                    new DateTime(2025, 4, 14, 17, 00, 0),
                    new DateTime(2025, 4, 14, 19, 00, 0),
                2),
                Activity.Create(5,
                    "Build machine 3",
                    new DateTime(2025, 4, 20, 13, 00, 0),
                    new DateTime(2025, 4, 21, 13, 00, 0),
                2),
                Activity.Create(6,
                    "Build component 3",
                    new DateTime(2025, 4, 19, 13, 00, 0),
                    new DateTime(2025, 4, 19, 17, 00, 0),
                1),
                Activity.Create(7,
                    "Build component 4",
                    new DateTime(2025, 4, 19, 19, 10, 0),
                    new DateTime(2025, 4, 19, 21, 00, 0),
                1),
                Activity.Create(8,
                    "Build machine 4",
                    new DateTime(2025, 4, 21, 11, 30, 0),
                    new DateTime(2025, 4, 21, 23, 30, 0),
                2)
            };

            builder.HasData(activities);

            builder.HasMany(d => d.Workers).WithMany(p => p.Activities)
                .UsingEntity<Dictionary<string, object>>(
                    "ActivityWorker",
                    r => r.HasOne<Worker>().WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_ActivityWorker_Worker"),
                    l => l.HasOne<Activity>().WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ActivityWorker_Activity"),
                    j =>
                    {
                        j.HasKey("ActivityId", "WorkerId");
                        j.ToTable("ActivityWorker");
                        j.HasData(
                            new { ActivityId = 1, WorkerId = 1 },
                            new { ActivityId = 2, WorkerId = 1 },
                            new { ActivityId = 3, WorkerId = 1 },
                            new { ActivityId = 3, WorkerId = 2 },
                            new { ActivityId = 3, WorkerId = 3 },
                            new { ActivityId = 3, WorkerId = 4 },
                            new { ActivityId = 3, WorkerId = 5 },
                            new { ActivityId = 3, WorkerId = 6 },
                            new { ActivityId = 4, WorkerId = 1 },
                            new { ActivityId = 4, WorkerId = 2 },
                            new { ActivityId = 4, WorkerId = 3 },
                            new { ActivityId = 4, WorkerId = 4 },
                            new { ActivityId = 4, WorkerId = 5 },
                            new { ActivityId = 4, WorkerId = 6 },
                            new { ActivityId = 5, WorkerId = 1 },
                            new { ActivityId = 5, WorkerId = 2 },
                            new { ActivityId = 5, WorkerId = 3 },
                            new { ActivityId = 5, WorkerId = 4 },
                            new { ActivityId = 5, WorkerId = 5 },
                            new { ActivityId = 5, WorkerId = 6 },
                            new { ActivityId = 6, WorkerId = 2 },
                            new { ActivityId = 7, WorkerId = 2 },
                            new { ActivityId = 8, WorkerId = 2 },
                            new { ActivityId = 8, WorkerId = 6 }
                        );
                    });
        }
    }
}
