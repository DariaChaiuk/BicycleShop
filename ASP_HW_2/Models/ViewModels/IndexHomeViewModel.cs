using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models.ViewModels
{
    public class IndexHomeViewModel
    {
        public SelectList Popularity { get; set; }
        public SelectList Models { get; set; }
        public SelectList Prices { get; set; }
        public SelectList Companies { get; set; }
        public SelectList Years { get; set; }
        public SelectList Countries { get; set; }
    }
}
