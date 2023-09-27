using MarkitingAPI.Model;
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
        public IActionResult GetAllservices()
        {
            List<Ourservices> servicess = context.Ourservicess.ToList();

            return Ok(servicess);
        }
    }
}
