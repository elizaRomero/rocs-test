using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities.Activities
{
    public class CreateActivity
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected DateTime StartDate { get; set; }
        protected DateTime EndDate { get; set; }
        protected int TypeId { get; }
        protected ActivityType Type { get; set; }
        protected IReadOnlyCollection<Worker> Workers { get; set; }

        protected Activity Result { get; set; }

        public void CreatingActivity()
        {
            Result = Activity.Create(Id, Name, StartDate, EndDate, Type, Workers);
        }
    }
}
