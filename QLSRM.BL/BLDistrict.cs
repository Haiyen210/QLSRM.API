using QLSRM.DL;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.BL
{
    public class BLDistrict : BLBase
    {
        public DLDistrict _dLDistrict { get; set; }
     

        public BLDistrict()
        {
            _dLDistrict = new DLDistrict();
           
        }
        public List<District> GetDistrictByProvince(long Id)
        {
            return _dLDistrict.GetDistrictByProvince(Id);
        }
    }
}
