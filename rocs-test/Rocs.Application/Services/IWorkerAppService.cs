using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.DTO;

namespace Rocs.Application.Services
{
    public interface IWorkerAppService
    {
        Task AddWorker(int id, string name);

        Task<Worker> GetWorkerById(int id);

        Task<ICollection<WorkerActivity>> GetTop10Workers();
    }
}
