using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyOrderController : BaseController<DailyOrder>
    {
        public DailyOrderController(BLDailyOrder blBase) : base(blBase)
        {
        }
    }
}
