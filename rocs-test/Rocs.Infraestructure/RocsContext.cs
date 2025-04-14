using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Rocs.Domain.Entities;
using Rocs.DTO;
using Rocs.Infraestructure.Configuration;

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
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerActivityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public class RocsContextFactory : IDesignTimeDbContextFactory<RocsContext>
        {
            public RocsContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RocsContext>();

                optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=true;TrustServerCertificate=True; Initial Catalog=RocsTest;User ID=sa;Password=admin123");

                return new RocsContext(optionsBuilder.Options);
            }
        }
    }
}
