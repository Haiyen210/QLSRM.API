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
    public class DeliveryAssignmentsController : BaseController<DeliveryAssignments>
    {
       public BLDeliveryAssignments _bLDeliveryAssignments { get; set; }
        public DeliveryAssignmentsController(BLDeliveryAssignments blBase) : base(blBase)
        {
            _bLDeliveryAssignments = new BLDeliveryAssignments();
        }
        
    }
}
