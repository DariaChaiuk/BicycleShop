using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class Bicycle
    {
        public int BicycleId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Company { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public Popularity Popularity { get; set; }
    }

    public enum Popularity
    {
        one,
        two,
        three,
        four,
        five
    }
}
