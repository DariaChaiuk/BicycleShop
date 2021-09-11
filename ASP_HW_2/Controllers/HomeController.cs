using ASP_HW_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Controllers
{
    public class HomeController: Controller
    {
        BicycleContext context;

        public HomeController(BicycleContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var bicycles = context.Bicycles.ToList();
            return View(bicycles);
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            Bicycle bicycleSelected;
            if (id != null)
            {
               bicycleSelected = context.Bicycles.FirstOrDefault(x => x.BicycleId == id);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(bicycleSelected);
        }

        [HttpPost]

        public IActionResult Order(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return View("~/Views/Home/Thanks.cshtml");
        }
    }
}
