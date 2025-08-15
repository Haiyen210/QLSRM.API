using QLSRM.DL;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.BL
{
    public class BLCommune : BLBase
    {
        public DLCommune _dlCommune { get; set; }


        public BLCommune()
        {
            _dlCommune = new DLCommune();

        }
        public List<District> GetCommuneByDistric(long Id)
        {
            return _dlCommune.GetCommuneByDistric(Id);
        }
    }
}
