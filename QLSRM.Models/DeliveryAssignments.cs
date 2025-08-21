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
        public string AccountName { get; set; }
        public string CustomerName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
        public string CommuneName { get; set; }
        public string Address { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? AssignedAt { get; set; }
        public int DeliveryStatus { get; set; }
        public DateTime? DeliveredAt { get; set; }//Thời gian giao hàng thực tế
        public string DeliveryNotes { get; set; }
    }
}