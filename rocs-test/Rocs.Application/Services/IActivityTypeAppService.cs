using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Application.Services
{
    public interface IActivityTypeAppService
    {
        Task AddActivityType(int id, string name, int restHours, int limitWorkers);

        Task<ActivityType> GetActivityTypeById(int id);

        Task<ICollection<ActivityType>> GetAllActivityTypes();

    }
}
