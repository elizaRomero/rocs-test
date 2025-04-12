using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.DTO;

namespace Rocs.Application.Services
{
    public interface IActivityAppService
    {
        Task AddActivityType(int id, string name, int restHours, int limitWorkers);

        Task<ActivityType> GetActivityTypeById(int id);

        Task<ICollection<ActivityType>> GetAllActivityTypes();

        Task<int> AddActivity(NewActivity newActivity);

        Task<Activity> GetActivityById(int id);
    }
}
