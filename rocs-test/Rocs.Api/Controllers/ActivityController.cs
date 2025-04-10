using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rocs.Application.Services;

namespace Rocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityAppService activityAppService;

        public ActivityController(IActivityAppService _activityAppService)
        {
            activityAppService = _activityAppService;
        }

        [HttpPost]
        [Route("activityType")]
        public async Task<IActionResult> AddActivityType(int id, string name, int restHours, int limitWorkers)
        {
            await activityAppService.AddActivityType(id, name, restHours, limitWorkers);
            return Ok();
        }

        [HttpGet("activityType/{id}")]
        public async Task<IActionResult> GetActivityTypeById(int id)
        {
            var response = await activityAppService.GetActivityTypeById(id);
            return Ok(response);
        }


        [HttpGet]
        [Route("activityTypes")]
        public async Task<IActionResult> GetAllActivityTypes()
        {
            var response = await activityAppService.GetAllActivityTypes();
            return Ok(response);
        }
    }
}
