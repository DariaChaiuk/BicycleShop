using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class Bicycle
    {
        public int BicycleId { get; set; }

        [Required(ErrorMessage = "Enter model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter year")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Enter company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Enter image url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Enter price")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Enter country")]
        public string Country { get; set; }
        public Popularity Popularity { get; set; }

        static public Popularity StringToPopularity(string popularity)
        {
            switch (popularity.ToUpper())
            {
                case "ONE":
                    return Popularity.one;

                case "TWO":
                    return Popularity.two;
        
                case "THREE":
                    return Popularity.three;
                   
                case "FOUR":
                    return Popularity.four;
                    
                default:
                    return Popularity.five;
                    
            }
        }
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
