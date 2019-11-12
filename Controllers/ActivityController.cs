using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManager.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LeadManager.Controllers
{
    [ApiController]
    [Route("activity")]
    public class ActivityController : ControllerBase
    {

        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for querying all Activities
        /// </summary>
        /// <param name="leadId"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/lead={leadId}")]
        [ProducesResponseType(typeof(List<ActivityResponse>), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetAllActivities(int leadId)
        {
            // HANDLE ENPOINT HERE
            return Ok();
        }

        /// <summary>
        /// Endpoint for querying all Activities
        /// </summary>
        /// <param name="leadId"></param> 
        /// <param name="id"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/leadId={leadId}&id={id}")]
        [ProducesResponseType(typeof(List<ActivityResponse>), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetActivity(int leadId, int id)
        {
            // HANDLE ENPOINT HERE
            return Ok();
        }

        /// <summary>
        /// Endpoint for querying all Activities
        /// </summary>
        /// <param name="leadId"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpPost("/{leadId}")]
        [ProducesResponseType(typeof(ActivityResponse), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> AddActivities(int leadId)
        {
            // HANDLE ENPOINT HERE
            return Ok();
        }
    }
}
