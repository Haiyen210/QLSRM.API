using QLSRM.DL;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.BL
{
    public class BLDailyOrder : BLBase
    {
        public DLDailyOrder _dlDaiLyOrder { get; set; }
        public BLDailyOrder()
        {
            _dlDaiLyOrder = new DLDailyOrder();
        }
        public List<DailyOrder> GetDailyOrderByCustomer(long customerId)
        {
            return _dlDaiLyOrder.GetDailyOrderByCustomer(customerId);
        }

        
    }
}
