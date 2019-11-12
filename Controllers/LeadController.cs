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
    [Route("lead")]
    public class LeadController : ControllerBase
    {

        private readonly ILogger<LeadController> _logger;

        public LeadController(ILogger<LeadController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for querying all Leads
        /// </summary>
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/")]
        [ProducesResponseType(typeof(List<LeadResponse>), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetAllLeads()
        {
            // HANDLE ENPOINT HERE
            return Ok();
        }

        /// <summary>
        /// Endpoint for querying all Leads
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("/{id}")]
        [ProducesResponseType(typeof(LeadResponse), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetLead(int id)
        {
            // HANDLE ENPOINT HERE
            return Ok();
        }
    }
}
