using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account>
    {
        public BLAccount _bLAccount { get; set; }
        public AccountController(BLAccount blBase) : base(blBase)
        {
            _bLAccount = new BLAccount();
        }
        [HttpGet("SelectAllAccountRoleShipper")]
        public async Task<IActionResult> SelectAllAccountRoleShipper()
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_bLAccount.SelectAllAccountRoleShipper());

            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
