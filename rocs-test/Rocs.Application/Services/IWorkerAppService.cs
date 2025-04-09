using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Application.Services
{
    public interface IWorkerAppService
    {
        Task AddWorker(int id, string name);

        Task<Worker> GetWorkerById(int id);
    }
}
