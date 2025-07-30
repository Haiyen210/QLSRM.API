using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class Commune : BaseEntity
    {
        public string CommuneCode { get; set; }
        public string CommuneName { get; set; }
        public long DistrictId { get; set; }
        public int Status { get; set; }
    }
}