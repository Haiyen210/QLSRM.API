using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models.Respones
{
    public class DashboardStatistics
    {
        public int TotalMealsToday { get; set; }
        public int DeliveredToday { get; set; }
        public int NotDeliveredToday { get; set; }
        public int CustomersToFollowUp { get; set; }
    }
}
