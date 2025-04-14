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
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasData(
                Worker.Create(1, "A"),
                Worker.Create(2, "B"),
                Worker.Create(3, "C"),
                Worker.Create(4, "D"),
                Worker.Create(5, "E"),
                Worker.Create(6, "F")); 
        }
    }
}
