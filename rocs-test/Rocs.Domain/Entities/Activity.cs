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

        public Activity(int id, string name, DateTime startDate, DateTime endDate, int typeId, ActivityType type)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            TypeId = typeId;
            Type = type;
        }
    }
}
