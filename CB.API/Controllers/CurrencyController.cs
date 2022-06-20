using CB.Core.Domain.Commands;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly IRepository<Currency> _repository;
        private readonly IMediator _mediator;

        public CurrencyController(IRepository<Currency> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<IEnumerable<Currency>> GetAll()
        {
            var result = await _repository.GetAll();
            return result;
        }
        [HttpGet("Get/{name}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Currency>> GetByName(string name)
        {
            var result = await _repository.Get(c => c.Name == name);
            return result;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut(template: "Edit")]
        public async Task<IActionResult> Edit([FromBody] EditCurrencyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete(template: "Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCurrencyCommand command)
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
