using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;

namespace Rocs.Infraestructure.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        RocsContext db;
        public ActivityRepository(RocsContext _db)
        {
            db = _db;
        }

        public async Task AddActivity(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            await db.AddAsync(activity);
            await db.SaveChangesAsync();
        }

        public Task DeleteActivity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetActivityById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
