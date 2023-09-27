using MarkitingAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomresController : ControllerBase
    {

        private readonly MyContext context;
        public CustomresController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("Addcustomer")]
        public IActionResult Addcustomer(Ourcustomers_success customer)
        {
            if (customer.Image != null)
            {
                context.ourcustomers_Successess.Add(customer);
                context.SaveChanges();
            }
            return Ok(customer);
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            List<Ourcustomers_success> customers = context.ourcustomers_Successess.ToList();

            return Ok(customers);
        }

    }
}
