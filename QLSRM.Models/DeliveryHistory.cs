using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class DeliveryHistory :BaseEntity
    {
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public int DeliveryNote { get; set; }
        public decimal Price { get; set; }
        public int OrderType { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
