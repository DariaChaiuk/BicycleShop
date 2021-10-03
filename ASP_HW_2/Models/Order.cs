using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter user address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter user contact phone")]
        public string ContactPhone { get; set; }
        public int BicycleId {get;set;}
        public Bicycle Bicycle { get; set; }
    }
}
