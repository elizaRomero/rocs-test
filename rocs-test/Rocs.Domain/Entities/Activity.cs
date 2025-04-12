using System;
using System.Collections;
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

        private Activity(int id, string name, DateTime startDate, DateTime endDate, int typeId)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            TypeId = typeId;
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
            IsEndDateAfterStartDate(startDate, endDate);
            if (string.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("The name cannot be null or empty");
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

        public void UpdateDates(DateTime startDate, DateTime endDate)
        {
            IsEndDateAfterStartDate(startDate, endDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        private static void IsEndDateAfterStartDate(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate) 
                throw new ArgumentException("End date must be after the start date");
        }
    }
}
