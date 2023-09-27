using MarkitingAPI.Model;
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
        public IActionResult GetAllAdvertisng()
        {
            List<Advertisingcampaigns> AllAdvertis = context.Advertisingcampaignss.ToList();

            return Ok(AllAdvertis);
        }
    }
}
