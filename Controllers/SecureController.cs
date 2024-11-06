using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseApiJwtAndBasicsAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("jwt")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetWithJwt()
        {
            return Ok("Acceso con JWT");
        }

        [HttpGet("basic")]
        [Authorize(AuthenticationSchemes = "Basic")]
        public IActionResult GetWithBasic()
        {
            return Ok("Acceso con Autenticación Básica");
        }
    }
}
