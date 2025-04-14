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
        
        Task<int> AddActivity(NewActivity newActivity);

        Task<Activity> GetActivityById(int id);

        Task DeleteActivity(int id);

        Task UpdateActivity(UpdateActivity updateActivity);
    }
}
