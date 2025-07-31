using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class Customer:BaseEntity
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int OrderType { get; set; }
        public long ComboId { get; set; }
        public string ComboName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ComboPrice { get; set; }
        public int TotalMealsPurchased { get; set; } //Tổng số suất ăn trong ngày
        public int MealsRemaining { get; set; } //Số suất ăn còn lại
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public string Note { get; set; } 
        public int Status { get; set; }
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long CommuneId { get; set; }
        public string CommuneName { get; set; }
        public string GenderName
        {
            get
            {
                var genderName = "Nữ";
                if (Gender == 1)
                {
                    genderName = "Nam";
                }
                return genderName;
            }
        }
    }
}
