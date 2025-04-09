using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocs.Domain.Entities
{
    public class ActivityType
    {
        public int Id { get; }
        public string Name { get; set; }

        public int RestHours { get; set; }
        public int LimitWorkers { get; set; }

        public ActivityType(int id, string name, int restHours, int limitWorkers)
        {
            Id = id;
            Name = name;
            RestHours = restHours;
            LimitWorkers = limitWorkers;
        }
    }
}
