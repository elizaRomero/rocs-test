using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;

namespace Rocs.Application.Services
{
    public class ActivityAppService : IActivityAppService
    {
        private readonly IActivityTypeRepository activityTypeRepository;
        public ActivityAppService(IActivityTypeRepository _activityTypeRepository)
        {
            activityTypeRepository = _activityTypeRepository;
        }

        public async Task AddActivityType(int id, string name, int restHours, int limitWorkers)
        {
            var activityType = ActivityType.Create(id, name, restHours, limitWorkers);
            await activityTypeRepository.AddActivityType(activityType);
        }

        public async Task<ActivityType> GetActivityTypeById(int id)
        {
            return await activityTypeRepository.GetActivityTypeById(id);
        }

        public async Task<ICollection<ActivityType>> GetAllActivityTypes()
        {
            return await activityTypeRepository.GetAllActivityTypes();
        }
    }
}
