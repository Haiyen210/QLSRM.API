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
        public override void AfterSaveData<T>(List<T> datas)
        {
            base.AfterSaveData(datas);
            if (datas?.Count > 0)
            {
                var orderList = new List<DailyOrder>();
                foreach (var o in datas)
                {
                    DeliveryAssignments deliveryAssignment = Common.Commonfunc.CastToSpecificType<DeliveryAssignments>(o);

                    if (deliveryAssignment != null && deliveryAssignment.EditMode == EditMode.Add)
                    {
                        var dailyOrder = _dlBase.GetById<DailyOrder>(deliveryAssignment.OrderId);
                    }
                    if (deliveryAssignment != null && deliveryAssignment.EditMode == EditMode.Update)
                    {

                        if(deliveryAssignment.DeliveryStatus == (int)OrderStatus.SuccessfulDelivery || deliveryAssignment.DeliveryStatus == (int)OrderStatus.CancelOrder)
                        {
                            var dailyOrder = _dlBase.GetById<DailyOrder>(deliveryAssignment.OrderId);

                            if (dailyOrder != null)
                            {
                                dailyOrder.Status = deliveryAssignment.DeliveryStatus;
                                dailyOrder.EditMode = EditMode.Update;
                                orderList.Add(dailyOrder);
                            }
                        }
                    }
                   
                }
                if(orderList.Count > 0)
                {
                    SaveData(orderList);
                }
            
            }
        }
    }
}
