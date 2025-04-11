using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;
using Rocs.DTO;

namespace Rocs.Application.Services
{
    public class ActivityAppService : IActivityAppService
    {
        private readonly IActivityTypeRepository activityTypeRepository;
        private readonly IWorkerRepository workerRepository;

        public ActivityAppService(
            IActivityTypeRepository _activityTypeRepository,
            IWorkerRepository _workerRepository)
        {
            activityTypeRepository = _activityTypeRepository;
            workerRepository = _workerRepository;
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

        public async Task<int> AddActivity(NewActivity newActivity)
        {
            //Review that the sent typeId exists.
            var activityType = await activityTypeRepository.GetActivityTypeById(newActivity.TypeId);
            if (activityType == null){
                throw new InvalidOperationException("Activity type does not exist");
            }

            //Review that all Workers exist.
            var workers = await workerRepository.GetWorkersByIds(newActivity.WorkersIds);
            if (workers.Count() != newActivity.WorkersIds.Count){
                throw new InvalidOperationException("Not all sent workers exist");
            }
            var activity = Activity.Create(0, newActivity.Name, newActivity.StartDate, newActivity.EndDate, activityType, workers.ToArray());

            //await activityRepository.AddActivity(_activity);
            return activity.Id;
        }
    }
}
