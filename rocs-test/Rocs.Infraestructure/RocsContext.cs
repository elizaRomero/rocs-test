using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rocs.Domain.Entities;

namespace Rocs.Infraestructure
{
    public class RocsContext : DbContext
    {
        public RocsContext(DbContextOptions<RocsContext> options) : base(options)
        {
        }
        public DbSet<Worker> Worker { get; set; }

        public DbSet<ActivityType> ActivityType { get; set; }

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
            base.OnModelCreating(modelBuilder);
        }
    }
}
