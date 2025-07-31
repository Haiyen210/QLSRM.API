
using QLSRM.DL;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.BL
{
    public class BLAccount : BLBase
    {
        public DLAccount _dlAccount { get; set; }

        public BLAccount()
        {
            _dlAccount = new DLAccount();
        }
        public Account? Login(LoginParam login)
        {
            return _dlAccount.Login(login);
        }
    }
}
