﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rocs.Application.Services;
using Rocs.DTO;

namespace Rocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityAppService activityAppService;
        private readonly IActivityTypeAppService activityTypeAppService;

        public ActivityController(IActivityAppService _activityAppService, 
            IActivityTypeAppService _activityTypeAppService)
        {
            activityAppService = _activityAppService;
            activityTypeAppService = _activityTypeAppService;
        }

        [HttpPost]
        [Route("activityType")]
        public async Task<IActionResult> AddActivityType(int id, string name, int restHours, int limitWorkers)
        {
            await activityTypeAppService.AddActivityType(id, name, restHours, limitWorkers);
            return Ok();
        }

        [HttpGet("activityType/{id}")]
        public async Task<IActionResult> GetActivityTypeById(int id)
        {
            var response = await activityTypeAppService.GetActivityTypeById(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("activityTypes")]
        public async Task<IActionResult> GetAllActivityTypes()
        {
            var response = await activityTypeAppService.GetAllActivityTypes();
            return Ok(response);
        }

        [HttpPost]
        [Route("activity")]
        public async Task<IActionResult> AddNewActivity([FromBody] NewActivity newActivity)
        {
            var activityId = await activityAppService.AddActivity(newActivity);
            return Ok(activityId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var response = await activityAppService.GetActivityById(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            await activityAppService.DeleteActivity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActivity([FromBody] UpdateActivity updateActivity)
        {
            await activityAppService.UpdateActivity(updateActivity);
            return Ok();
        }
    }
}
