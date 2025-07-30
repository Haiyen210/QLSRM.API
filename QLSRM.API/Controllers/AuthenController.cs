using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NTH.WOW.Common;
using QLSRM.BL;
using QLSRM.Common;
using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;
using QLSRM.Respones;
using System.Data;
namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginParam login)
        {
            var response = new Response();
            try
            {
                if (login != null && !string.IsNullOrWhiteSpace(login.UserName) && !string.IsNullOrWhiteSpace(login.Password))
                {
                    var blAccount = new BLAccount();
                    var account = blAccount.Login(login);
                    if (account != null)
                    {
                        var token = AuthozirationUtility.RenderAccessToken(account);
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            LoginRespone res = new LoginRespone() { Token = $"{JwtBearerDefaults.AuthenticationScheme} {token}", User = account };
                            response.SetSuccess(res);
                        }
                    }
                    else
                    {
                        response.SetError(ErrorCode.EmployeeNotFound, "Không tìm thấy tài khoản");
                    }
                }
                else
                {
                    response.SetError(ErrorCode.InvalidParam, "Tham số không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] List<Account> account)
        {

            var response = new Response();
            try
            {
                var blAccount = new BLAccount();
                if (account?.Count > 0)
                {
                    foreach (var item in account)
                    {
                        item.Status = (int)MemberStatus.Active;
                    }
                    var accounts = blAccount.SaveData(account);
                    if (accounts)
                    {
                        response.SetSuccess(accounts);
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
        //[HttpPost("RegisterEmployee")]
        //public async Task<IActionResult> RegisterEmployee([FromBody] List<Employee> employee)
        //{

        //    var response = new Response();
        //    try
        //    {
        //        if (employee?.Count > 0)
        //        {
        //            var _blEmployee = new BLEmployee();
        //            _blEmployee.ValidateEmployee(employee?.FirstOrDefault(), ref response);
        //            if (response.Success)
        //            {
        //                foreach (var item in employee)
        //                {
        //                    item.Status = (int)StatusEmployee.WaitActive;
        //                    item.Roles = (int)Roles.Member;
        //                    item.PositionId = 1;
        //                    item.PositionName = "Thành viên";
        //                }
        //                var employees = _blEmployee.SaveData(employee);
        //                if (employees)
        //                {
        //                    string subject = "[Thế giới việc làm] Đăng ký tài khoản thành công";
        //                    if (employee?.Count > 0)
        //                    {
        //                        var e = employee[0];
        //                        var content = "Chúc mừng bạn đã kích hoạt thành công tài khoản người lao động.\r\nBạn có thêm nguồn thu nhập từ vị trí của mình trong dự án  World Of Work.\r\nXin cảm ơn!";
        //                        if (!string.IsNullOrWhiteSpace(content))
        //                        {
        //                            EmailHelper.SendEmail(e.Email, subject, content);
        //                        }
        //                    }
        //                    response.SetSuccess(employees);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.SetError(ErrorCode.Unknown, ex.ToString());
        //    }

        //    return StatusCode(StatusCodes.Status200OK, response);
        //}
        ///// <summary>
        ///// Gửi OTP quên mật khẩu
        ///// </summary>
        ///// <param name="payRewards"></param>
        ///// <returns></returns>
        //[HttpPost("SendOTPForgetPassword")]
        //public async Task<IActionResult> SendOTPForgetPassword(Employee employee)
        //{

        //    var response = new Response();
        //    try
        //    {
        //        var _blBase = new BLBase();
        //        var _blActiveCode = new BLActiveCode();
        //        if (employee.Email != null)
        //        {

        //            var resultEmployee = _blBase.SelectEmployeeByEmail<Employee>(employee.Email);
        //            if (resultEmployee != null)
        //            {
        //                string otp = new Random().Next(1000000).ToString("D6");
        //                var transactionId = Guid.NewGuid().ToString();
        //                var activeCode = new ActiveCode { SendDate = DateTime.Now, Code = otp, ActiveType = resultEmployee.GetType().Name, TransactionId = transactionId, EditMode = EditMode.Add };
        //                var success = _blActiveCode.SaveData(new List<ActiveCode> { activeCode });
        //                if (success)
        //                {
        //                    resultEmployee.TransactionId = transactionId;
        //                    string subject = "[Thế giới việc làm] Mã OTP - Quên mật khẩu";
        //                    if (resultEmployee.Email != null)
        //                    {
        //                        var templateEmail = ConfigUtil.GetAppSettings<string>(AppSettingKeys.EmailOTP);
        //                        if (System.IO.File.Exists(templateEmail))
        //                        {
        //                            var content = System.IO.File.ReadAllText(templateEmail);
        //                            if (!string.IsNullOrWhiteSpace(content))
        //                            {
        //                                content = content.Replace("##To_Email##", resultEmployee.Email).Replace("##OTP_Code##", otp);
        //                                EmailHelper.SendEmail(employee.Email, subject, content);
        //                                response.Data = resultEmployee;
        //                            }
        //                        }

        //                    }
        //                    else
        //                    {
        //                        response.SetError(ErrorCode.EmployeeNotFound, "Tài khoản này không có email!");
        //                    }
        //                    return StatusCode(StatusCodes.Status200OK, response);
        //                }
        //                else
        //                {
        //                    response.SetError(ErrorCode.Unknown, "Gửi OTP không thành công!");
        //                }
        //            }
        //            else
        //            {
        //                response.SetError(ErrorCode.Unknown, "Email không hợp lệ!");
        //            }



        //        }
        //        else
        //        {
        //            response.SetError(ErrorCode.Unknown, "Vui lòng nhập email!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.SetError(ErrorCode.Unknown, ex.ToString());
        //    }

        //    return StatusCode(StatusCodes.Status200OK, response);
        //}


        ///// <summary>
        ///// Gửi OTP quên mật khẩu
        ///// </summary>
        ///// <param name="payRewards"></param>
        ///// <returns></returns>
        //[HttpPost("AcceptOTPForgetPassword")]
        //public async Task<IActionResult> AcceptOTPForgetPassword(Employee employee)
        //{
        //    var response = new Response();
        //    try
        //    {
        //        var _blBase = new BLBase();
        //        var _blActiveCode = new BLActiveCode();
        //        if (employee != null)
        //        {
        //            if (!string.IsNullOrWhiteSpace(employee.ActiveCode))
        //            {
        //                var employeeOld = _blBase.SelectEmployeeByEmail<Employee>(employee.Email);
        //                if (employeeOld != null)
        //                {
        //                    List<Employee> employeeArray = new List<Employee>();
        //                    var activeCode = _blActiveCode.SelectActiveCodeByCodeAndTransactionId(employee.ActiveCode, employee.TransactionId);
        //                    if (activeCode != null && DateTime.Now.Subtract(activeCode.SendDate).TotalMinutes < 5)
        //                    {
        //                        employeeOld.Password = employee.Password;
        //                        employeeOld.EditMode = EditMode.Update;
        //                        employeeArray.Add(employeeOld);
        //                        _blBase.SaveData(employeeArray);
        //                    }
        //                    else
        //                    {
        //                        response.SetError(ErrorCode.InvalidActiveCode, "Mã xác nhận không hợp lệ!");
        //                    }

        //                }
        //                else
        //                {
        //                    response.SetError(ErrorCode.EmployeeNotFound, "Tài khoản này không tồn tại không tồn tại!");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            response.SetError(ErrorCode.InvalidActiveCode, "Mã xác nhận không hợp lệ!");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        response.SetError(ErrorCode.Unknown, ex.ToString());
        //    }

        //    return StatusCode(StatusCodes.Status200OK, response);
        //}


    }
}
