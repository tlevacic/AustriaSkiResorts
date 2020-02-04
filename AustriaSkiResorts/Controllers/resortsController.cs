using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AustriaSkiResorts.Models;

namespace AustriaSkiResorts.Controllers
{
   
    public class resortsController : Controller
    {
        private readonly resortContext _context;

        public resortsController(resortContext context)
        {
            _context = context;
        }



        public void updateAvailablenumberOfTermins(int Id)
        {
            var newResort = new resort() { id = Id };
            int availableNbr = (from s in _context.resort
                      where s.id == Id
                      select s.availableNumberOfTermins).First();

            newResort.availableNumberOfTermins = --availableNbr;
            _context.Attach(newResort);
            _context.Entry(newResort).Property("availableNumberOfTermins").IsModified = true;
            _context.SaveChanges();
        }


        [HttpPost]
        public IActionResult successfullyOrder(String id,String day,String month,String year,String time)
        {
            updateAvailablenumberOfTermins(int.Parse(id));
            ViewData["day"] = day;
            ViewData["month"] = month;
            ViewData["year"] = year;
            ViewData["time"] = time;
            return View();
        }
        // GET: resorts
        public async Task<IActionResult> Index(String sort)
        {
            if (sort != null)
            {
                var input = sort.ToString();

              if(input.Equals("Price - low to high"))
                return View(await _context.resort.OrderBy(a => a.price).ToListAsync());
            
              if(input.Equals("Alphabetically: A-Z"))
                return View(await _context.resort.OrderBy(a => a.name).ToListAsync());

                if (input.Equals("Alphabetically: Z-A"))
                    return View(await _context.resort.OrderByDescending(a => a.name).ToListAsync());
            }

            return View(await _context.resort.OrderByDescending(a => a.price).ToListAsync());
        }

        // GET: resorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.resort
                .FirstOrDefaultAsync(m => m.id == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // GET: resorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: resorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,country,length,height,price,snowRange,shortInfo,longInfo,urlPicture,availableNumberOfTermins")] resort resort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resort);
        }

        // GET: resorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.resort.FindAsync(id);
            if (resort == null)
            {
                return NotFound();
            }
            return View(resort);
        }

        // POST: resorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,country,length,height,price,snowRange,shortInfo,longInfo,urlPicture,availableNumberOfTermins")] resort resort)
        {
            if (id != resort.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!resortExists(resort.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resort);
        }

        // GET: resorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.resort
                .FirstOrDefaultAsync(m => m.id == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // POST: resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resort = await _context.resort.FindAsync(id);
            _context.resort.Remove(resort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool resortExists(int id)
        {
            return _context.resort.Any(e => e.id == id);
        }
    }
}
