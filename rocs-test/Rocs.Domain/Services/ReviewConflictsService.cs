using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Services
{
    public class ReviewConflictsService : IReviewConflictsService
    {
        public IEnumerable<string> ReviewConflicts(Activity activity)
        {
            var conflictList = new List<string>();

            foreach (var worker in activity.Workers)
            {
                foreach (var workerActivity in worker.Activities)
                {
                    if (workerActivity.Id == activity.Id)
                        continue;

                    bool overlaps = activity.StartDate < workerActivity.EndDate && 
                                    activity.EndDate > workerActivity.StartDate;

                    bool insufficientRestAfterExistingTask = activity.StartDate > workerActivity.EndDate && 
                                                             activity.StartDate <= workerActivity.EndDate.AddHours(workerActivity.Type.RestHours);
                    
                    bool insufficientRestBeforeExistingTask = activity.EndDate < workerActivity.StartDate && 
                                                              workerActivity.StartDate <= activity.EndDate.AddHours(activity.Type.RestHours); 

                    if (overlaps)
                        conflictList.Add($"Worker {worker.Id} - {worker.Name} has a conflict with activity {workerActivity.Id} - {workerActivity.Name}");
                    
                    if (insufficientRestAfterExistingTask)
                        conflictList.Add($"Worker {worker.Id} - {worker.Name} has not completed the required {workerActivity.Type.RestHours} hours of rest after activity {workerActivity.Id} - {workerActivity.Name}.");
                    
                    if (insufficientRestBeforeExistingTask)
                        conflictList.Add($"Worker {worker.Id} - {worker.Name}  won't have completed {activity.Type.RestHours} hours of rest before activity {workerActivity.Id} - {workerActivity.Name}.");
                }
            }

            return conflictList;
        }
    }
}
