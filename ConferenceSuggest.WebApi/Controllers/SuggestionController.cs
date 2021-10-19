using ConferenceSuggest.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceSuggest.WebApi.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SuggestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<List<Models.Conference>> Get([FromQuery] GetSuggestions.Query query)
        {
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
