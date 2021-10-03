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
        int itemsOnPage = 10;

        public HomeController(BicycleContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int? page)
        {

                var bicycles = context.Bicycles.ToList();
                if (page == null || page < 0)
                {
                    page = 0;
                }
         
                ViewBag.page = page;
                ViewBag.IsFinished = false;
                if ((int)page * itemsOnPage < bicycles.Count && (page * itemsOnPage + itemsOnPage) < bicycles.Count)
                {
                    var futureDiff = bicycles.Count - ((page + 1) * itemsOnPage);
                    if (futureDiff <= 0)
                    {
                        ViewBag.IsFinished = true;
                    }
                    return View(bicycles.GetRange((int)(page * 10), itemsOnPage));
                }
                var diff = bicycles.Count - (page * itemsOnPage);
                if (diff > 0)
                {
                    ViewBag.IsFinished = true;
                    return View(bicycles.GetRange((int)(page * 10), (int)diff));
                }

                return View(bicycles.GetRange((int)(page * 10), itemsOnPage));
            

        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
                
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Bicycle bicycleSelected = context.Bicycles.FirstOrDefault(x => x.BicycleId == id);
                ViewBag.Bicycle = bicycleSelected;
                return View();
            }
          
        }

        [HttpPost]

        public IActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return View("~/Views/Home/Thanks.cshtml");
            }
            else
            {
                var bicycle = context.Bicycles.FirstOrDefault(x => x.BicycleId == order.BicycleId);
                ViewBag.Bicycle = bicycle;
                return View(order);
            }
        }
    }
}
