using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; }
        public int NotificationType { get; set; }
        public string ActionDescription { get; set; }
        public int Status { get; set; }
    }
}
