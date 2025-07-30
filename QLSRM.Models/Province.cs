using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class Province : BaseEntity
    {
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public int Status { get; set; }
    }
}