using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Respones
{
    public class LoginRespone
    {
        public string Token { get; set; }
        public Account User { get; set; }
    }
}
