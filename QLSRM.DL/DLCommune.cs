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
    public class DLCommune : DLBase
    {
        private MySqlConnection _connection { get; set; }
        public DLCommune()
        {
            _connection = new MySqlConnection(ConfigUtil.GetAppSettings<string>(AppSettingKeys.ConnectionString));

        }

        public List<District> GetCommuneByDistric(long Id)
        {
            return ExecuteReader<District>("Proc_SelectCommuneById", new { Id });
        }
    }
}
