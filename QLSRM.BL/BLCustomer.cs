using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QLSRM.BL
{
    public class BLCustomer : BLBase
    {
        public DLCustomer _dlCustomer { get; set; }
        public DLDailyOrder _dlDailyOrder { get; set; }

        public BLCustomer()
        {
            _dlCustomer = new DLCustomer();
            _dlDailyOrder = new DLDailyOrder();
        }

        public override void AfterSaveData<T>(List<T> datas)
        {
            try
            {
                base.AfterSaveData(datas);
                if (datas?.Count > 0)
                {
                    var orderDaily = new List<DailyOrder>();
                    var notification = new List<Notification>();
                    decimal price = 0;
                    int quantity = 0;
                    foreach (var o in datas)
                    {
                        Customer customer = Common.Commonfunc.CastToSpecificType<Customer>(o);
                        var combo = _dlBase.GetById<ComboTypes>(customer.ComboId);

                        if (customer != null && customer.EditMode == EditMode.Add)
                        {
                            if (customer.OrderType == 1)
                            {
                                DateTime startDate = customer.StartDate;
                                DateTime endDate = customer.EndDate;
                                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                                {
                                    var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");
                                    if (combo.NumberOfDate != 0)
                                    {
                                        price = Math.Round(customer.ComboPrice / combo.NumberOfDate, 2);
                                        quantity = combo.TotalMeals / combo.NumberOfDate;
                                    }
                                    orderDaily.Add(new DailyOrder()
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
                                        Quantity = quantity,
                                        Status = (int)OrderStatus.WaitDelivery,
                                        Note = customer.Note,
                                        Price = price,
                                        DeliveryDate = date,
                                        EditMode = EditMode.Add,
                                    });
                                }

                            }
                            else
                            {
                                var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");
                                orderDaily.Add(new DailyOrder()
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
                                    Quantity = customer.TotalMealsPurchased,
                                    Status = (int)OrderStatus.WaitDelivery,
                                    Note = customer.Note,
                                    Price = customer.ComboPrice,
                                    DeliveryDate = DateTime.Now,
                                    EditMode = EditMode.Add,
                                });

                            }
                            notification.Add(new Notification()
                            {
                                Message = "Khách hàng " + customer.CustomerName + " đã đăng ký thành công!",
                                NotificationType = (int)ActionNotifi.AddCustomer,
                                ActionDescription = "Thêm khách hàng mới",
                                Status = (int)StatusNoti.Active,
                            });

                        }
                        if (customer != null && customer.EditMode == EditMode.Update)
                        {
                            var deviveryHistory = new List<DeliveryHistory>();
                            List<DailyOrder> orderDetail = _dlDailyOrder.GetDailyOrderByCustomer(customer.Id);
                            if (orderDetail?.Count > 0)
                            {
                                foreach (var item in orderDetail)
                                {
                                    deviveryHistory.Add(new DeliveryHistory()
                                    {
                                        OrderId = item.Id,
                                        Price = item.Price,
                                        DeliveryDate = item.DeliveryDate,
                                        OrderCode = item.OrderCode,
                                        OrderType = item.OrderType,
                                        Quantity = item.Quantity,
                                        Status = (int)OrderStatus.CancelOrder,
                                        EditMode = EditMode.Add
                                    });


                                }
                                if (deviveryHistory?.Count > 0)
                                {
                                    SaveData(deviveryHistory);
                                }

                                orderDetail.ForEach(o =>
                                {
                                    o.EditMode = EditMode.Update;
                                    o.Status = (int)OrderStatus.CancelOrder;
                                });
                                if (orderDetail?.Count > 0)
                                {
                                    SaveData(orderDetail);
                                }
                            }
                            if (customer.OrderType == 1)
                            {
                                DateTime startDate = customer.StartDate;
                                DateTime endDate = customer.EndDate;

                                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                                {
                                    var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");

                                    if (combo.NumberOfDate != 0)
                                    {
                                        price = Math.Round(customer.ComboPrice / combo.NumberOfDate, 2);
                                        quantity = combo.TotalMeals / combo.NumberOfDate;
                                    }
                                    orderDaily.Add(new DailyOrder()
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
                                        Quantity = quantity,
                                        Status = (int)OrderStatus.WaitDelivery,
                                        Note = customer.Note,
                                        Price = price,
                                        DeliveryDate = date,
                                        EditMode = EditMode.Add,
                                    });
                                }
                            }
                            else
                            {
                                var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");
                                orderDaily.Add(new DailyOrder()
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
                                    Quantity = customer.TotalMealsPurchased,
                                    Status = (int)OrderStatus.WaitDelivery,
                                    Note = customer.Note,
                                    Price = customer.ComboPrice,
                                    DeliveryDate = DateTime.Now,
                                    EditMode = EditMode.Add,
                                });
                            }

                        }
                    }
                    if (orderDaily?.Count > 0)
                    {
                        SaveData(orderDaily);
                    }
                    if (notification?.Count > 0)
                    {

                        SaveData(notification);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu dữ liệu DailyOrder: " + ex);
                throw ex;

            }
        }
    }
}
