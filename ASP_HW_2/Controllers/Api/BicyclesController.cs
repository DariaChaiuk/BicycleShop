using ASP_HW_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BicyclesController : Controller
    {
        private readonly BicycleContext context;
        public BicyclesController(BicycleContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Bicycle>>> Get()
        {
            return await context.Bicycles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> Get(int id)
        {
            Bicycle bicycle = await context.Bicycles.FirstOrDefaultAsync(x => x.BicycleId == id);
            if(bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        [HttpPost]
        public async Task<ActionResult<Bicycle>> Post(Bicycle bicycle)
        {
          
            if(bicycle.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price cannot be 0 or less");
            }
            if(bicycle.Year < 1900 )
            {
                ModelState.AddModelError("Year", "Year cannot be 1900 or less");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            context.Bicycles.Add(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpPut]
        public async Task<ActionResult<Bicycle>> Put(Bicycle bicycle)
        {
            if (bicycle.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price cannot be 0 or less");
            }
            if (bicycle.Year < 1900)
            {
                ModelState.AddModelError("Year", "Year cannot be 1900 or less");
            }

            if (bicycle == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!context.Bicycles.Any(x => x.BicycleId == bicycle.BicycleId))
            {
                return NotFound();
            }

            context.Update(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> Delete(int id)
        {
            Bicycle bicycle = await context.Bicycles.FirstOrDefaultAsync(x => x.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }
            context.Bicycles.Remove(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }
    }
}
