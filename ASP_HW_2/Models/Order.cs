using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public int BicycleId {get;set;}
        public Bicycle Bicycle { get; set; }
    }
}
