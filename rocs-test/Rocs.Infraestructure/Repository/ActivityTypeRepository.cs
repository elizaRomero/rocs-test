using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;

namespace Rocs.Infraestructure.Repository
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        RocsContext db;

        public ActivityTypeRepository(RocsContext _db)
        {
            db = _db;
        }

        public async Task AddActivityType(ActivityType activityType)
        {
            await db.AddAsync(activityType);
            await db.SaveChangesAsync();
        }

        public async Task<ActivityType> GetActivityTypeById(int id)
        {
            return await db.ActivityType.FindAsync(id);
        }

        public Task<ICollection<ActivityType>> GetAllActivityTypes()
        {
            throw new NotImplementedException();
        }
    }
}
