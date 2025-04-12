using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Activity> GetActivityById(int id)
        {
            var activity = await db.Activity
                        .Include(a => a.Workers)
                        .FirstOrDefaultAsync(a => a.Id == id);
            return activity;
        }
    }
}
