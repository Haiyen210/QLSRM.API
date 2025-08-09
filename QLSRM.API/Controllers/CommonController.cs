using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Common;
using QLSRM.Library;
using QLSRM.Models;
using QLSRM.Models.Respones;
using System.IdentityModel.Tokens.Jwt;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        public BLAccount _blAccount { get; set; }
        public BLDailyOrder _bLDailyOrder { get; set; }
        public CommonController()
        {
            _blAccount = new BLAccount();
            _bLDailyOrder = new BLDailyOrder();
        }

        [HttpGet]
        [HttpGet("getuserinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var response = new Response();
            try
            {
                var UserInfo = new UserInfoRespone();
                var userId = AuthozirationUtility.GetClaim<long>(JwtRegisteredClaimNames.Sid);
                UserInfo.User = _blAccount.GetById<Account>(userId);
                if (UserInfo.User != null )
                {
                    UserInfo.dashboard = _blAccount.GetDashboardStatistics();
                }
                response.SetSuccess(UserInfo);
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpGet("GetTodayDeliveryOrders")]
        public async Task<IActionResult> GetTodayDeliveryOrders()
        {
            var response = new Response();
            try
            {
                var dailyOrder = _bLDailyOrder.GetTodayDeliveryOrders();
                response.SetSuccess(dailyOrder);
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
