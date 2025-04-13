using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rocs.Application.Services;

namespace Rocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerAppService workerAppService;

        public WorkerController(IWorkerAppService _workerAppService)
        {
            workerAppService = _workerAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorker(int id, string name)
        {
            await workerAppService.AddWorker(id, name);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorker(int id)
        {
            var response = await workerAppService.GetWorkerById(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("top10Workers")]
        public async Task<IActionResult> GetTop10Workers()
        {
            var response = await workerAppService.GetTop10Workers();
            return Ok(response);
        }
    }
}
