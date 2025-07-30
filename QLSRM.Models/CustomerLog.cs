using Microsoft.AspNetCore.Mvc.Abstractions;
using QLSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSRM.Models
{
    public class CustomerLog : BaseEntity
    {
        public long CustomerId { get; set; }
        public int ActionType { get; set; } //"CREATE_CUSTOMER", "UPDATE_CUSTOMER", "PAUSE_COMBO", "CANCEL_ORDER"
        public string ActionDescription { get; set; }
    }
}
