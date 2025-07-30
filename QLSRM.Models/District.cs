using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QLSRM.Models
{
    public class District : BaseEntity
    {
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public long ProvinceId { get; set; }
        public int Status { get; set; }
    }
}