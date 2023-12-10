using DomainLayer.DTO.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("LogIn")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            // get User By Email
            //if user == null return false
            // we need to hash password from request 
            // if user pass != hashed pass return false 
            // else create token and return it 

            return Ok();


        }
    }
}
