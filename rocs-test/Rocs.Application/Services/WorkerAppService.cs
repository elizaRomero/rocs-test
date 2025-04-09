using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;

namespace Rocs.Application.Services
{
    public class WorkerAppService : IWorkerAppService
    {
        private readonly IWorkerRepository workerRepository;
        public WorkerAppService(IWorkerRepository _workerRepository)
        {
            workerRepository = _workerRepository;
        }

        public async Task AddWorker(int id, string name)
        {
            var worker = Worker.Create(id, name);
            await workerRepository.AddWorker(worker);
        }

        public async Task<Worker> GetWorkerById(int id)
        {
            return await workerRepository.GetWorkerById(id);
        }
    }
}
