using QLSRM.Library;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.BL
{
    public class BLDeliveryAssignments : BLBase
    {
        public BLDeliveryAssignments()
        {
        }


        public override void PreSaveData<T>(List<T> datas)
        {
            base.PreSaveData(datas);
            if (datas?.Count > 0)
            {
                foreach (var o in datas)
                {
                    DeliveryAssignments employee = Common.Commonfunc.CastToSpecificType<DeliveryAssignments>(o);
                  
                    if (employee != null && employee.EditMode == EditMode.Add)
                    {
                       
                    }
                    if (employee != null && employee.EditMode == EditMode.Update)
                    {
                      

                    }
                   
                }
            }
        }
    }
}
