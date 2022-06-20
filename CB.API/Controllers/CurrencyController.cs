using CB.Core.Domain.Commands;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IRepository<Currency> _repository;
        private readonly IMediator _mediator;

        public CurrencyController(IRepository<Currency> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(CreateCurrencyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
