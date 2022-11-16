using TodoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.IService;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateTokenController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthentication _authenticationService;

        public GenerateTokenController(IConfiguration config,IAuthentication authenticationService)
        {
            _config = config;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GenerateToken([FromBody] UserLogin userLogin)
        {
            var user = _authenticationService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _authenticationService.Generate(user,_config);
                return Ok(token);
            }

            return Forbid("User not found");
        }
    }
}