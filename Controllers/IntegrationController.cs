using System;
using System.Collections.Generic;
using System.Linq;
using LeadManager.Mappers;
using System.Threading.Tasks;
using LeadManager.Models;
using LeadManager.Responses;
using LeadManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeadManager.Requests;

namespace LeadManager.Controllers
{
    [ApiController]
    [Route("integration")]
    public class IntegrationController : ControllerBase
    {

        private readonly ILogger<LeadController> _logger;
        private readonly ILeadService _leadService;

        public IntegrationController(ILogger<LeadController> logger, ILeadService leadService)
        {
            _logger = logger;
            _leadService = leadService;
        }

        /// <summary>
        /// Endpoint for bulk load leads for integration purposes
        /// </summary>
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet]
        [Route("leads")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> BulkLoadLeads([FromBody] List<LeadRequest> request)
        {
            try
            {
                var response = await _leadService.BulkLoadLeads(request.Select(l => l.ToLead()).ToList());
                if (response.Ok)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new ErrorPayload(1, "An error occurred!"));
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }
    }
}
