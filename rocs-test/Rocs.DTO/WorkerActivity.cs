using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocs.DTO
{
    public class WorkerActivity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalHours { get; set; }

        public int TotalHoursNext7Days { get; set; }
    }
}
