using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurworksController : ControllerBase
    {
        private readonly MyContext context;
        public OurworksController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("AddWork")]
        public IActionResult AddWork(Ourworks works)
        {
            if (works.Image != null)
            {
                context.Ourworkss.Add(works);
                context.SaveChanges();
            }
            return Ok(works);
        }
        [HttpGet]
        [Route("GetAllworks")]
        public IActionResult GetAllworks()
        {
            List<Ourworks> works = context.Ourworkss.ToList();

            return Ok(works);
        }


    }
}
