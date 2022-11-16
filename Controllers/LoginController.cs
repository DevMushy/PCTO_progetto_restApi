using TodoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.IService;
using TodoApi.Service;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private AuthService _IAuth;

        public LoginController(IConfiguration config,AuthService IAuth)
        {
            _config = config;
            _IAuth = IAuth;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _IAuth.Authenticate(userLogin);

            if (user != null)
            {
                var token = _IAuth.Generate(user,_config);
                return Ok(token);
            }

            return Forbid("User not found");
        }
    }
}