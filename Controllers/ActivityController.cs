using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManager.Models;
using LeadManager.Requests;
using LeadManager.Responses;
using LeadManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeadManager.Mappers;

namespace LeadManager.Controllers
{
    [ApiController]
    [Route("activity")]
    public class ActivityController : ControllerBase
    {

        private readonly ILogger<ActivityController> _logger;
        private readonly IActivityService _activityService;

        public ActivityController(ILogger<ActivityController> logger, IActivityService activityService)
        {
            _logger = logger;
            _activityService = activityService;
        }

        /// <summary>
        /// Endpoint for querying all Activities by Lead
        /// </summary>
        /// <param name="leadId"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/lead={leadId}")]
        [ProducesResponseType(typeof(List<Activity>), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetAllActivities(int leadId)
        {
            try
            {
                var activities = await _activityService.GetActivitiesByLeadId(leadId);
                return Ok(activities);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }

        /// <summary>
        /// Endpoint for querying Activity by its Id
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/{id}")]
        [ProducesResponseType(typeof(Activity), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetActivity(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityById(id);
                return Ok(activity);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }

        /// <summary>
        /// Endpoint for registering new Activity
        /// </summary>
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpPost("/")]
        [ProducesResponseType(typeof(Activity), 201)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> AddActivity([FromBody] ActivityRequest request)
        {
            try
            {
                var activity = await _activityService.Create(request.ToActivity());
                return CreatedAtAction(nameof(GetActivity), activity);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }
    }
}
