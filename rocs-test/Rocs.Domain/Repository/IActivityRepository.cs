using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Repository
{
    public interface IActivityRepository
    {
        Task AddActivity(Activity activity);

        Task<Activity> GetActivityById(int id);

        Task DeleteActivity(int id);

        Task UpdateActivity(Activity activity);
    }
}
