using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly MyContext context;
        public AdminsController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string name, string password)
        {
          Admin admin=  context.admins.FirstOrDefault(a=>a.Name==name&&a.Password==password);
            if(admin != null)
            {
                return Ok("username and password is correct");
            }
            return NotFound("user name and password not found");
        }
    }
}
