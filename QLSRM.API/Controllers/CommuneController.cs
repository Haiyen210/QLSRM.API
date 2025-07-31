using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommuneController : BaseController<Commune>
    {
        public CommuneController(BLCommune blBase) : base(blBase)
        {
        }
    }
}
