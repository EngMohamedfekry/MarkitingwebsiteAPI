using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly MyContext context;
        public ServicesController(MyContext _context)
        {
            context = _context;

        }

        [HttpPost]
        [Route("Addservices")]
        [Authorize]
        public IActionResult Addservices(Ourservices ourservices)
        {
            if (ourservices.Image != null &&ourservices.Name!=null)
            {
                context.Ourservicess.Add(ourservices);
                context.SaveChanges();
            }
            return Ok(ourservices);
        }
        [HttpGet]
        [Route("GetAllservices")]
        [Authorize]
        public IActionResult GetAllservices()
        {
            List<Ourservices> servicess = context.Ourservicess.ToList();

            return Ok(servicess);
        }
        [HttpDelete]
        [Route("Deleteservices")]
        [Authorize]
        public IActionResult Deleteservices(int id)
        {
            Ourservices serve = context.Ourservicess.FirstOrDefault(a => a.Id == id);
            context.Ourservicess.Remove(serve);
            context.SaveChanges();

            return Ok();
        }
    }
}
