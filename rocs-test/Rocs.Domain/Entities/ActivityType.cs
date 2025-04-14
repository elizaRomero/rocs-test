using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rocs.Domain.Entities
{
    public class ActivityType
    {
        public int Id { get; }
        public string Name { get; set; }

        public int RestHours { get; set; }
        public int LimitWorkers { get; set; }

        [JsonIgnore]
        public virtual IReadOnlyCollection<Activity> Activities { get; set; } = new List<Activity>();

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
                throw new ArgumentNullException(nameof(name), "The name cannot be null or empty");
            }
            if (restHours < 0){
                throw new ArgumentOutOfRangeException(nameof(restHours), "Rest hours cannot be negative");
            }
            if (limitWorkers <= 0){
                throw new ArgumentOutOfRangeException(nameof(limitWorkers), "Limit workers must be greater than zero");
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
