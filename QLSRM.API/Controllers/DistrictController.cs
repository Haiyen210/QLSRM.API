using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Library;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController<District>
    {
        public BLDistrict _bLDistrict { get; set; }
        public DistrictController(BLDistrict blBase) : base(blBase)
        {
            _bLDistrict = new BLDistrict();
        }
        [HttpGet("selectByProviceId")]
        public async Task<IActionResult> selectByProviceId(long id)
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_bLDistrict.GetDistrictByProvince(id));

            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
