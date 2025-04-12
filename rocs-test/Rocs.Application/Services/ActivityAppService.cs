using Rocs.Domain.Entities;
using Rocs.Domain.Repository;
using Rocs.Domain.Services;
using Rocs.DTO;

namespace Rocs.Application.Services
{
    public class ActivityAppService : IActivityAppService
    {
        private readonly IActivityTypeRepository activityTypeRepository;
        private readonly IActivityRepository activityRepository;
        private readonly IWorkerRepository workerRepository;
        private readonly IReviewConflictsService reviewConflictsService;

        public ActivityAppService(
            IActivityTypeRepository _activityTypeRepository,
            IActivityRepository _activityRepository,
            IWorkerRepository _workerRepository,
            IReviewConflictsService _reviewConflictsService)
        {
            activityTypeRepository = _activityTypeRepository;
            activityRepository = _activityRepository;
            workerRepository = _workerRepository;
            reviewConflictsService = _reviewConflictsService;
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

            // Review overlaps and rest time.
            var conflicts = reviewConflictsService.ReviewConflicts(activity);
            if (conflicts.Any())
                throw new InvalidOperationException(string.Join("\n", conflicts));

            await activityRepository.AddActivity(activity);
            return activity.Id;
        }

        public async Task<Activity> GetActivityById(int id)
        {
            return await activityRepository.GetActivityById(id);
        }

        public async Task DeleteActivity(int id)
        {
            await activityRepository.DeleteActivity(id);
        }
    }
}
