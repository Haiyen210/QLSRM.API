using QLSRM.DL;
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
                var deviveryHistory = new List<DeliveryHistory>();
                var customerList = new List<Customer>();
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
                                deviveryHistory.Add(new DeliveryHistory()
                                {
                                    OrderId = dailyOrder.Id,
                                    Price = dailyOrder.Price,
                                    DeliveryDate = dailyOrder.DeliveryDate,
                                    OrderCode = dailyOrder.OrderCode,
                                    OrderType = dailyOrder.OrderType,
                                    Quantity = dailyOrder.Quantity,
                                    Status = deliveryAssignment.DeliveryStatus,
                                    EditMode = EditMode.Add
                                });
                                if(deliveryAssignment.DeliveryStatus == (int)OrderStatus.SuccessfulDelivery)
                                {
                                    var customer = _dlBase.GetById<Customer>(dailyOrder.CustomerId);
                                    if (customer != null)
                                    {
                                        customer.EditMode = EditMode.Update;
                                        int quantityOrdered = Math.Max(0, dailyOrder.Quantity);
                                        customer.MealsRemaining = customer.MealsRemaining - quantityOrdered;
                                        customer.MealsUsed = customer.MealsUsed + quantityOrdered;
                                        customerList.Add(customer);
                                    }
                                }
                            }
                        }
                    }
                   
                }
                if(orderList.Count > 0)
                {
                    SaveData(orderList);
                }
                if (deviveryHistory.Count > 0)
                {
                    SaveData(deviveryHistory);
                }
                if (customerList.Count > 0)
                {
                    SaveData(customerList);
                }
            }
        }
    }
}
