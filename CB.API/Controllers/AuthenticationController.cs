using CB.Core.Domain.DTO;
using CB.Core.Domain.Entities.Authorization;
using CB.Core.Domain.Interfaces;
using CB.Core.Service.Abstractions;
using CB.Core.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IAuthenticationRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<string>> Authenticate([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _repository.Get(model.Username, model.Password);

            if (user is null)
                return NotFound(new { message = "Invalid username or password" });

            var token = _tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
