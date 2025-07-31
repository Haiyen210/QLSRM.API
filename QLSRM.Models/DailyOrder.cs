using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class DailyOrder : BaseEntity
    {
        public string OrderCode { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long ComboId { get; set; }
        public string ComboName { get; set; }
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long CommuneId { get; set; }
        public string CommuneName { get; set; }
        public DateTime DeliveryDate { get; set; } //Ngày giao hàng
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int OrderType { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public byte CancelledByCustomer { get; set; }
    }
}