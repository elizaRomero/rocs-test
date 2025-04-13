using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rocs.Domain.Entities;
using Rocs.DTO;

namespace Rocs.Infraestructure
{
    public class RocsContext : DbContext
    {
        public RocsContext(DbContextOptions<RocsContext> options) : base(options)
        {
        }
        public DbSet<Worker> Worker { get; set; }

        public DbSet<ActivityType> ActivityType { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<WorkerActivity> WorkerActivity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("ActivityType");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.Id);
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type).WithMany(p => p.Activities)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ActivityType");

                entity.HasMany(d => d.Workers).WithMany(p => p.Activities)
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
                        });
            });

            modelBuilder.Entity<WorkerActivity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
