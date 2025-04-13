using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rocs.Domain.Entities;
using Rocs.Domain.Repository;
using Rocs.DTO;

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
                            .Include(w => w.Activities)  // include the collection of activities
                            .ThenInclude(a => a.Type)
                            .ToListAsync();
        }

        public async Task<ICollection<WorkerActivity>> GetTop10Workers()
        {
            var query = @"SELECT TOP 10	w.Id, 
				                        w.Name, 
				                        SUM(DATEDIFF(HOUR, a.StartDate, a.EndDate)) AS TotalHours,     
				                        SUM(DATEDIFF(HOUR, 
						                        CASE 
							                        WHEN a.StartDate > GETDATE() THEN a.StartDate 
							                        ELSE GETDATE() 
						                        END, 
						                        CASE 
							                        WHEN a.EndDate < DATEADD(DAY, 7, GETDATE()) THEN a.EndDate 
							                        ELSE DATEADD(DAY, 7, GETDATE()) 
						                        END)) AS TotalHoursNext7Days
                                                    FROM Activity a
                                              INNER JOIN ActivityWorker aw on a.Id = aw.ActivityId
                                              INNER JOIN Worker w on w.Id = aw.WorkerId 
                                                   WHERE a.StartDate < DATEADD(DAY, 7, GETDATE())
						                             AND a.EndDate > GETDATE()
                                                GROUP BY w.Id, w.Name
                                                ORDER BY TotalHoursNext7Days DESC;";

            return await db.Set<WorkerActivity>()
                .FromSqlRaw(query)
                .ToListAsync();
        }

    }
}
