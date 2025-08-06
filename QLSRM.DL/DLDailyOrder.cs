using MySql.Data.MySqlClient;
using QLSRM.Common;
using QLSRM.Library;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.DL
{
    public class DLDailyOrder : DLBase
    {
        private MySqlConnection _connection { get; set; }
        public DLDailyOrder()
        {
            _connection = new MySqlConnection(ConfigUtil.GetAppSettings<string>(AppSettingKeys.ConnectionString));

        }

        public List<DailyOrder> GetDailyOrderByCustomer(long customerId)
        {
            return ExecuteReader<DailyOrder>("Proc_GetDailyOrderByCustomer", new { customerId });


        }
    }
}
