using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Library;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommuneController : BaseController<Commune>
    {
        public BLCommune _bLCommune { get; set; }
        public CommuneController(BLCommune blBase) : base(blBase)
        {
            _bLCommune = new BLCommune();
        }
        [HttpGet("selectByDistricId")]
        public async Task<IActionResult> selectByDistricId(long id)
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_bLCommune.GetCommuneByDistric(id));

            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
