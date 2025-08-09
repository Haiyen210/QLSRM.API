using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models.Respones
{
    public class TodayDeliveryOrder
    {
        public int STT { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Combo { get; set; }
        public int Quantity { get; set; }
        public int MealsRemaining { get; set; }
        public string Shipper { get; set; }
    }
}
