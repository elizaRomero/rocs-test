using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Repository
{
    public interface IWorkerRepository
    {
        Task<Worker> GetWorkerById(int id);

        Task AddWorker(Worker worker);

        Task<IEnumerable<Worker>> GetWorkersByIds(IReadOnlyCollection<int> ids);
    }
}
