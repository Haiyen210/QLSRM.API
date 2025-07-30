using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class ComboTypes:BaseEntity
    {
        public string ComboCode { get; set; }
        public string ComboName { get; set; }
        public int TotalMeals { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        
    }
}
