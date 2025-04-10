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

        /// <summary>
        /// The creation of an Activity is handled by the Create method, applying the following rules:
        /// 1. The Activity name must not be null or empty.
        /// 2. The Start Date must be earlier than the End Date.
        /// 3. The number of workers must not exceed the worker limit defined by the related ActivityType.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="activityType"></param>
        /// <param name="workers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Activity Create(int id, string name, DateTime startDate, DateTime endDate, ActivityType activityType, IReadOnlyCollection<Worker> workers)
        {
            if (string.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("The name cannot be null or empty");
            }
            if (!IsValidDateRange(startDate, endDate)){
                throw new ArgumentException("End date cannot be earlier than start date");
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

        private static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }
    }
}
