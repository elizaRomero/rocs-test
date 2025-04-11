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
    public class WorkerRepository : IWorkerRepository
    {
        RocsContext db;
        public WorkerRepository(RocsContext _db)
        {
            db = _db;
        }

        public async Task AddWorker(Worker worker)
        {
            await db.AddAsync(worker);
            await db.SaveChangesAsync();
        }

        public async Task<Worker> GetWorkerById(int id)
        {
            return await db.Worker.FindAsync(id);
        }

        public async Task<IEnumerable<Worker>> GetWorkersByIds(IReadOnlyCollection<int> ids)
        {
            return await db.Set<Worker>()
                            .Where(x => ids.Contains(x.Id))
                            .ToListAsync();
        }
    }
}
