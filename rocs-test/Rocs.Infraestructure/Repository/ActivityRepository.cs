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

        public async Task<Activity> GetActivityById(int id)
        {
            var activity = await db.Activity
                        .Include(a => a.Workers)
                        .FirstOrDefaultAsync(a => a.Id == id);
            return activity;
        }

        public async Task DeleteActivity(int id)
        {
            try
            {
                var activity = await db.Activity.FindAsync(id);
                if (activity != null)
                {
                    db.Activity.Remove(activity);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("The activity could not be deleted due to referential integrity constraints.", ex);
            }
        }

    }
}
