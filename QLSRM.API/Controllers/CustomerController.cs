
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(BLCustomer blBase) : base(blBase)
        {
        }
    }
}
