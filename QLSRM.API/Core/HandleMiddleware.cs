
using QLSRM.Common;
using QLSRM.Library;
using System.IdentityModel.Tokens.Jwt;

namespace QLSRM.API.Core
{
    public class HandleMiddleware
    {
        private readonly RequestDelegate _next;


        public HandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            AuthozirationUtility.SetHttpContext(context);
            // set role cho toàn bộ session của user
            Session.Role = AuthozirationUtility.GetClaim<int>(Constant.mscRoles);
            Session.UserId = AuthozirationUtility.GetClaim<long>(JwtRegisteredClaimNames.Sid);
            Session.UserCode = AuthozirationUtility.GetClaim<string>(JwtRegisteredClaimNames.Name);

            await _next(context);
        }
    }
}
