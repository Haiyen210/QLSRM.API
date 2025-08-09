using QLSRM.Models;
using QLSRM.Models.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.DL
{
    public class DLAccount : DLBase
    {
        public DLAccount()
        {
        }
        public Account? Login(LoginParam login)
        {
            return ExecuteReader<Account>("Proc_Login", login).FirstOrDefault();
        }
        public DashboardStatistics? GetDashboardStatistics()
        {
            return ExecuteReader<DashboardStatistics>("sp_GetDashboardStatistics", null).FirstOrDefault();
        }
    }
}
