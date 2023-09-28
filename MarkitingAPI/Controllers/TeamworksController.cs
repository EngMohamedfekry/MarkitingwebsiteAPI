using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        public IActionResult GetAllTeam()
        {
            List<workteam> teams = context.workteams.ToList();

            return Ok(teams);
        }
        [HttpDelete]
        [Route("DeleteTeammember")]
        [Authorize]
        public IActionResult DeleteTeammember(int id)
        {
            workteam members = context.workteams.FirstOrDefault(a => a.Id == id);
            context.workteams.Remove(members);
            context.SaveChanges();

            return Ok();
        }
    }
}
