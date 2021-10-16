using ASP_HW_2.Models;
using ASP_HW_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<ActionResult> Index(int? page)
        {

            //var bicycles = context.Bicycles.ToList();
            //if (page == null || page < 0)
            //{
            //    page = 0;
            //}

            //ViewBag.page = page;
            //ViewBag.IsFinished = false;
            //if ((int)page * itemsOnPage < bicycles.Count && (page * itemsOnPage + itemsOnPage) < bicycles.Count)
            //{
            //    var futureDiff = bicycles.Count - ((page + 1) * itemsOnPage);
            //    if (futureDiff <= 0)
            //    {
            //        ViewBag.IsFinished = true;
            //    }
            //    return View(bicycles.GetRange((int)(page * 10), itemsOnPage));
            //}
            //var diff = bicycles.Count - (page * itemsOnPage);
            //if (diff > 0)
            //{
            //    ViewBag.IsFinished = true;
            //    return View(bicycles.GetRange((int)(page * 10), (int)diff));
            //}

            //return View(bicycles.GetRange((int)(page * 10), itemsOnPage));

            var models = await Task.Run(() => context.Bicycles.Select(x => x.Model).Distinct());
            var prices = await Task.Run(() => context.Bicycles.Select(x => x.Price).Distinct());
            var companies = await Task.Run(() => context.Bicycles.Select(x => x.Company).Distinct());
            var years = await Task.Run(() => context.Bicycles.Select(x => x.Year).Distinct());
            var countries = await Task.Run(() => context.Bicycles.Select(x => x.Country).Distinct());

            var model = new IndexHomeViewModel
            {
                Popularity = new SelectList(Enum.GetValues(typeof(Popularity)).Cast<Popularity>()),
                Models = new SelectList(models),
                Prices = new SelectList(prices),
                Companies = new SelectList(companies),
                Years = new SelectList(years),
                Countries = new SelectList(countries)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult BicyclesList(int? page, string sortType, string model, string popularity, string price, string company, int year, string country, string searchParam, string searchValue)
        {

            List<Bicycle> result = null;
            switch (sortType)
            {
                case "PopularityAsc":
                    result = context.Bicycles.OrderBy(x => x.Popularity).ToList();
                    break;
                case "ModelAsc":
                    result = context.Bicycles.OrderBy(x => x.Model).ToList();
                    break;
                case "PriceAsc":
                    result = context.Bicycles.OrderBy(x => x.Price).ToList();
                    break;
                case "CompanyAsc":
                    result = context.Bicycles.OrderBy(x => x.Company).ToList();
                    break;
                case "YearAsc":
                    result = context.Bicycles.OrderBy(x => x.Year).ToList();
                    break;
                case "CountryAsc":
                    result = context.Bicycles.OrderBy(x => x.Country).ToList();
                    break;
                default:
                    result = context.Bicycles.ToList();
                    break;
            }

            if(model != null)
            {
                result = result.Where(x => x.Model == model).ToList();
            }
            if (popularity != null)
            {
                result = result.Where(x => x.Popularity == Bicycle.StringToPopularity(popularity)).ToList();
            }
            if (price != null)
            {
                int filterPrice = Int32.Parse(price);
                result = result.Where(x => x.Price == filterPrice).ToList();
            }
            if (company != null)
            {
                result = result.Where(x => x.Company == company).ToList();
            }
            if (year != 0)
            {
                result = result.Where(x => x.Year == year).ToList();
            }
            if (country != null)
            {
                result = result.Where(x => x.Country == country).ToList();
            }

            if(searchParam != null && searchValue != null)
            {
                result = result.Where(x => x.GetType().GetProperty(searchParam).GetValue(x, null).ToString().Contains(searchValue)).ToList();
            }

            if (page == null || page <= 0)
            {
                ViewBag.Back = true;

                page = 0;
            }
            else
            {
                //if(page == 1)
                //{
                //    ViewBag.Back = true;
                //}
                //else
                //{
                ViewBag.Back = false;
                //}

                //ViewBag.Back = true;
            }


            // ViewBag.page = page;

            //ViewBag.IsFinished = false;



            if ((int)page * itemsOnPage < result.Count && (page * itemsOnPage + itemsOnPage) < result.Count)
            {
                var futureDiff = result.Count - ((page + 1) * itemsOnPage);
                if (futureDiff <= 0)
                {
                    //ViewBag.IsFinished = true;
                    ViewBag.Next = true;
                }

                result = result.GetRange((int)(page * 10), itemsOnPage);
                //  return View(result.GetRange((int)(page * 10), itemsOnPage));
            }
            else
            {
                var diff = result.Count - (page * itemsOnPage);

                if (diff > 0)
                {
                    // ViewBag.IsFinished = true;
                    ViewBag.Next = true;

                    result = result.GetRange((int)(page * 10), (int)diff);
                    // return View(result.GetRange((int)(page * 10), (int)diff));
                }
                else
                {
                    ViewBag.Next = true;
                }

            }

            if (ViewBag.Next == null)
            {
                ViewBag.Next = false;
            }

            ViewBag.IsFinished = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                next = ViewBag.Next,
                back = ViewBag.Back
            });

            //ViewBag.IsFinished = new
            //{
            //    Next = ViewBag.Next,
            //    Back = ViewBag.Back
            //};

            return PartialView(new BicyclesListViewModel
            {
                Bicycles = result,
                //Popularity = new SelectList(Enum.GetValues(typeof(Popularity)).Cast<Popularity>())
            //  Companies = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectListItems)
            });
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
