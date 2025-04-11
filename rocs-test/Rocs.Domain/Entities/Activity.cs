using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocs.Domain.Entities
{
    public class Activity
    {
        public int Id { get; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TypeId { get; set; }

        public virtual ActivityType Type { get; }

        public IReadOnlyCollection<Worker> Workers { get; set; }

        private Activity(int id, string name, DateTime startDate, DateTime endDate, int typeId, ActivityType type)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            TypeId = typeId;
            Type = type;
        }

        private Activity(int id, string name, DateTime startDate, DateTime endDate, ActivityType type, IReadOnlyCollection<Worker> workers)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            TypeId = type.Id;
            Type = type;
            Workers = workers;
        }

        public static Activity Create(int id, string name, DateTime startDate, DateTime endDate, ActivityType activityType, IReadOnlyCollection<Worker> workers)
        {
            if (string.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("The name cannot be null or empty");
            }
            if (endDate <= startDate){
                throw new ArgumentException("End date must be after the start date");
            }
            if (workers.Count() > activityType.LimitWorkers){
                throw new ArgumentException($"Activity cannot be performed by more than {activityType.LimitWorkers} worker(s).");
            }

            return new Activity(
                id,
                name,
                startDate,
                endDate,
                activityType,
                workers
            );
        }
    }
}
