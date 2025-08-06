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
        public BLCustomer _blCustomer { get; set; }
        public BLDailyOrder _blDailyOrder { get; set; }

        public BLCustomer()
        {
            _blCustomer = new BLCustomer();
        }

        public override void AfterSaveData<T>(List<T> datas)
        {
            base.AfterSaveData(datas);
            if (datas?.Count > 0)
            {
                var orderDaily = new List<DailyOrder>();
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
                                decimal price = 0;
                                int quantity = 0;
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
                            decimal price = 0;
                            int quantity = 0;
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
                    if (customer != null && customer.EditMode == EditMode.Update)
                    {
                        var deviveryHistory = new List<DeliveryHistory>();
                        List<DailyOrder> orderDetail = _blDailyOrder.GetDailyOrderByCustomer(customer.Id); // Lấy khách hàng mà trạng thái là chờ giao                      
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
                            orderDetail.ForEach(o => o.EditMode = EditMode.Delete);
                        }

                        if (deviveryHistory?.Count > 0 && orderDetail?.Count > 0)
                        {
                            SaveData(deviveryHistory);
                            SaveData(orderDetail);
                        }
                        if(customer.OrderType == 1)
                        {
                            DateTime startDate = customer.StartDate;
                            DateTime endDate = customer.EndDate;
                           
                            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                            {
                                var orderCode = _dlBase.SelectNewCode<string>("DailyOrder");
                                decimal price = 0;
                                int quantity = 0;
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
                            decimal price = 0;
                            int quantity = 0;
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
            }
        }
    }
}
