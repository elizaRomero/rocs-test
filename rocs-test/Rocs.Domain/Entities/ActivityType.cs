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

        private ActivityType(int id, string name, int restHours, int limitWorkers)
        {
            Id = id;
            Name = name;
            RestHours = restHours;
            LimitWorkers = limitWorkers;
        }

        public static ActivityType Create(int id, string name, int restHours, int limitWorkers)
        {
            if (string.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("The name cannot be null or empty");
            }
            return new ActivityType(
                id,
                name,
                restHours,
                limitWorkers
            );
        }
    }
}
