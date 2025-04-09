using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Repository
{
    public interface IActivityTypeRepository
    {
        Task<ICollection<ActivityType>> GetAllActivityTypes();

        Task<ActivityType> GetActivityTypeById(int id);

        Task AddActivityType(ActivityType activityType);
    }
}
