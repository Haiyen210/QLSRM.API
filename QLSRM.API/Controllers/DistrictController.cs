using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController<District>
    {
        public DistrictController(BLDistrict blBase) : base(blBase)
        {
        }
    }
}
