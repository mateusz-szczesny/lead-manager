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

namespace LeadManager.Controllers
{
    [ApiController]
    [Route("lead")]
    public class LeadController : ControllerBase
    {

        private readonly ILogger<LeadController> _logger;
        private readonly ILeadService _leadService;

        public LeadController(ILogger<LeadController> logger, ILeadService leadService)
        {
            _logger = logger;
            _leadService = leadService;
        }

        /// <summary>
        /// Endpoint for querying all Leads
        /// </summary>
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Lead>), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetAllLeads()
        {
            try
            {
                var leads = await _leadService.GetLeads();
                return Ok(leads);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }

        /// <summary>
        /// Endpoint for querying all Leads
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Ok - successful</response>
        /// <response code="400">Bad Request - error during request(Error in message)</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LeadResponse), 200)]
        [ProducesResponseType(typeof(ErrorPayload), 400)]
        public async Task<IActionResult> GetLead(int id)
        {
            try
            {
                var lead = await _leadService.GetLeadById(id);
                return Ok(lead.ToLeadResponse());
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorPayload(1, e.Message));
            }
        }
    }
}
