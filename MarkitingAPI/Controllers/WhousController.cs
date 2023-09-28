﻿using MarkitingAPI.Model;
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
        [Authorize]
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
        [Authorize]
        public IActionResult GetAllDescription()
        {
            List<whous> who = context.whouss.ToList();

            return Ok(who);
        }
        [HttpDelete]
        [Route("DeleteDescription")]
        [Authorize]
        public IActionResult DeleteDescription(int id)
        {
            whous us = context.whouss.FirstOrDefault(a => a.Id == id);
            context.whouss.Remove(us);
            context.SaveChanges();

            return Ok();
        }
    }
   
}
