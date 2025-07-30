using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class DeliveryAssignments : BaseEntity
    {
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public long AccountId { get; set; }
        public DateTime AssignedAt { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime DeliveredAt { get; set; }//Thời gian giao hàng thực tế
        public string DeliveryNotes { get; set; }
    }
}