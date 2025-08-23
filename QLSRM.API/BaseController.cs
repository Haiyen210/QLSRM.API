using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Common;
using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;

namespace QLSRM.API
{
    [Authorize]
    public class BaseController<TEntity> : ControllerBase
    {
        public BLBase    _blBase { get; set; }
        public BaseController(BLBase blBase)
        {
            _blBase = blBase;
        }
        [HttpPost("SaveData")]
        public virtual async  Task<IActionResult> SaveData(List<TEntity> datas)
        {
            var response = new Response();
            try
            {
                response.Data = _blBase.SaveData(datas,  response);
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpGet("SelectAll")]
        public async Task<IActionResult> SelectAll()
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_blBase.SelectAll<TEntity>());
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("selectnewcode")]
        public async Task<IActionResult> SelectNewCode()
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_blBase.SelectNewCode<string>(this.GetType().Name.Replace("Controller", "")));
            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("selectById")]
        public async Task<IActionResult> SelectById(long id)
        {
            var response = new Response();
            try
            {
                response.SetSuccess(_blBase.GetById<TEntity>(id));

            }
            catch (Exception ex)
            {
                response.SetError(ErrorCode.Unknown, ex.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
