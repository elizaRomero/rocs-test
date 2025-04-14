using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rocs.DTO;

namespace Rocs.Infraestructure.Configuration
{
    public class WorkerActivityConfiguration : IEntityTypeConfiguration<WorkerActivity>
    {
        public void Configure(EntityTypeBuilder<WorkerActivity> builder)
        {
            builder.HasNoKey();
            builder.ToView(null);
        }
    }
}
