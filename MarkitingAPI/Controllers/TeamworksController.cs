using MarkitingAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamworksController : ControllerBase
    {
        private readonly MyContext context;
        public TeamworksController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("AddFactor")]
        public IActionResult AddFactor(workteam factor)
        {
            if (factor.Image != null&&factor.Name!=null)
            {
                context.workteams.Add(factor);
                context.SaveChanges();
            }
            return Ok(factor);
        }
        [HttpGet]
        [Route("GetAllTeam")]
        public IActionResult GetAllTeam()
        {
            List<workteam> teams = context.workteams.ToList();

            return Ok(teams);
        }
    }
}
