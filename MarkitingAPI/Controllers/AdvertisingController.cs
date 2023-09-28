﻿using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        private readonly MyContext context;
        public AdvertisingController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("AddAdvertising")]
        [Authorize]
        public IActionResult AddAdvertising(Advertisingcampaigns advertisng)
        {
            if (advertisng.name!=null&& advertisng.Description!=null)
            {
                context.Advertisingcampaignss.Add(advertisng);
                context.SaveChanges();
            }
            return Ok(advertisng);
        }
        [HttpGet]
        [Route("GetAllAdvertisng")]
        [Authorize]
        public IActionResult GetAllAdvertisng()
        {
            List<Advertisingcampaigns> AllAdvertis = context.Advertisingcampaignss.ToList();

            return Ok(AllAdvertis);
        }
        [HttpDelete]
        [Route("DeleteAdvertising")]
        [Authorize]
        public IActionResult DeleteAdvertising(int id)
        {
            Advertisingcampaigns advertisingcampaigns = context.Advertisingcampaignss.FirstOrDefault(a => a.Id == id);
            context.Advertisingcampaignss.Remove(advertisingcampaigns);
            context.SaveChanges();

            return Ok();
        }
    }
}
