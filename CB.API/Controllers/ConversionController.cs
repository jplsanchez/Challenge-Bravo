using CB.Core.Domain.DTO;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces.Repositories;
using CB.Core.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _service;

        public ConversionController(IConversionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Convert([FromBody] ConversionDTO dto)
        {
            float value = await _service.Convert(dto);
            return Ok(value);
        }
    }
}
