using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSRM.BL;
using QLSRM.Models;

namespace QLSRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryAssignmentsController : BaseController<DeliveryAssignments>
    {
        public DeliveryAssignmentsController(BLDeliveryAssignments blBase) : base(blBase)
        {
        }
    }
}
