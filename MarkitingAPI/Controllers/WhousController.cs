using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhousController : ControllerBase
    {
        private readonly MyContext context;
        public WhousController(MyContext _context)
        {
            context =_context;

        }

        [HttpPost]
        [Route("AddDescription")]
        public IActionResult AddDescription(whous who)
        {
            if(who.Description != null)
            {
                context.whouss.Add(who);
                context.SaveChanges();
            }
            return Ok(who);
        }
        [HttpGet]
        [Route("GetAllDescription")]
        public IActionResult GetAllDescription()
        {
            List<whous> who = context.whouss.ToList();

            return Ok(who);
        }
    }
   
}
