﻿using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private readonly MyContext context;
        public ElectionController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("Addelection")]
        [Authorize]
        public IActionResult Addelection(Electioncampaigns election)
        {
            if (election.Image != null)
            {
                context.Electioncampaignss.Add(election);
                context.SaveChanges();
            }
            return Ok(election);
        }
        [HttpGet]
        [Route("GetAllelection")]
        [Authorize]
        public IActionResult GetAllelection()
        {
            List<Electioncampaigns> elections = context.Electioncampaignss.ToList();

            return Ok(elections);
        }
        [HttpDelete]
        [Route("Deleteelection")]
        [Authorize]
        public IActionResult Deleteelection(int id)
        {
            Electioncampaigns election = context.Electioncampaignss.FirstOrDefault(a => a.Id == id);
            context.Electioncampaignss.Remove(election);
            context.SaveChanges();

            return Ok();
        }
    }
}
