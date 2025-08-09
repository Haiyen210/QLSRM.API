using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;
using QLSRM.Models.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QLSRM.BL
{
    public class BLDailyOrder : BLBase
    {
        public DLDailyOrder _dlDaiLyOrder { get; set; }
        public BLDailyOrder()
        {
            _dlDaiLyOrder = new DLDailyOrder();
        }
        public List<DailyOrder> GetDailyOrderByCustomer(long customerId)
        {
            return _dlDaiLyOrder.GetDailyOrderByCustomer(customerId);
        }
        public List<TodayDeliveryOrder> GetTodayDeliveryOrders()
        {
            return _dlDaiLyOrder.GetTodayDeliveryOrders();
        }
        public override void AfterSaveData<T>(List<T> datas)
        {
            try
            {
                base.AfterSaveData(datas);
                if (datas?.Count > 0)
                {
                    var customerList = new List<Customer>();
                    var orderList = new List<DailyOrder>();
                    var deviveryHistory = new List<DeliveryHistory>();
                    foreach (var o in datas)
                    {
                        DailyOrder orderDaily = Common.Commonfunc.CastToSpecificType<DailyOrder>(o);
                        var customer = _dlBase.GetById<Customer>(orderDaily.CustomerId);
                        if (orderDaily != null && orderDaily.EditMode == EditMode.Update)
                        {
                            if (orderDaily.Status == (int)OrderStatus.CancelOrder)
                            {
                                if (customer.OrderType == 1)
                                {
                                    var newDeliveryDate = customer.EndDate.AddDays(1);
                                    customer.EndDate = newDeliveryDate;
                                    customer.EditMode = EditMode.Update;
                                    customerList.Add(customer);
                                    var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");
                                    orderList.Add(new DailyOrder()
                                    {
                                        CustomerId = customer.Id,
                                        OrderCode = orderCode,
                                        ComboId = customer.ComboId,
                                        ProvinceId = customer.ProvinceId,
                                        CommuneId = customer.CommuneId,
                                        DistrictId = customer.DistrictId,
                                        Address = customer.Address,
                                        PhoneNumber = customer.PhoneNumber,
                                        OrderType = customer.OrderType,
                                        Quantity = orderDaily.Quantity,
                                        Status = (int)OrderStatus.WaitDelivery,
                                        Note = customer.Note,
                                        Price = orderDaily.Price,
                                        DeliveryDate = newDeliveryDate,
                                        EditMode = EditMode.Add,
                                    });
                                }

                            }
                            if (orderDaily.Status == (int)OrderStatus.SuccessfulDelivery)
                            {
                                deviveryHistory.Add(new DeliveryHistory()
                                {
                                    OrderId = orderDaily.Id,
                                    Price = orderDaily.Price,
                                    DeliveryDate = orderDaily.DeliveryDate,
                                    OrderCode = orderDaily.OrderCode,
                                    OrderType = orderDaily.OrderType,
                                    Quantity = orderDaily.Quantity,
                                    Status = (int)OrderStatus.SuccessfulDelivery,
                                    EditMode = EditMode.Add
                                });

                                customer.EditMode = EditMode.Update;
                                int quantityOrdered = Math.Max(0, orderDaily.Quantity);
                                customer.MealsRemaining = customer.TotalMealsPurchased - quantityOrdered;
                                customerList.Add(customer);

                                if (deviveryHistory.Count > 0)
                                {
                                    SaveData(deviveryHistory);
                                }

                            }
                        }

                    }

                    if (customerList?.Count > 0)
                    {
                        SaveData(customerList);
                    }
                    if (orderList?.Count > 0)
                    {
                        SaveData(orderList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu dữ liệu DailyOrder: " + ex);
                throw; // giữ nguyên stack trace gốc

            }
        }


    }
}
