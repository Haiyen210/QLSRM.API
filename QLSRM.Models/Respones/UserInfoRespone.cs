using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models.Respones
{
    public class UserInfoRespone
    {
        public Account User { get; set; }
        public DashboardStatistics dashboard { get; set; }
    }
}
