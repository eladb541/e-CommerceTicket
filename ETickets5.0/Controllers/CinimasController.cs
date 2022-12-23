using ETickets5._0.Data;
using ETickets5._0.Data.Services;
using ETickets5._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class CinimasController : Controller
    {
        private readonly ICinemaService _service;
        public CinimasController(ICinemaService service)
        {
            _service=service;

        }
        public async Task<IActionResult> Index()

        {
            var allCinimas = await _service.getallasync();
            return View(allCinimas);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")]  Cinima cinimas)
        {
            if (!ModelState.IsValid)
            {
                return View(cinimas);
            }
            await _service.Addasync(cinimas);
            return RedirectToAction(nameof(Index));


        }
       
        public async Task<IActionResult> Details(int id)
        {
            var cinimas = await _service.GetByIdasync(id);
            if (cinimas == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            else
            {
                return View(cinimas);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cinimas = await _service.GetByIdasync(id);
            if (cinimas == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            else
            {
                return View(cinimas);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind(" Id,Logo, Name, Description")] Cinima cinima)
        {
            if (!ModelState.IsValid)
            {
                return View(cinima);
            }
            await _service.UpdateAsync(id, cinima);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            var cinima = await _service.GetByIdasync(id);
            if (cinima == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            else
            {
                return View(cinima);
            }

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinima = await _service.GetByIdasync(id);
            if (cinima == null)
            {
               
                return RedirectToAction("Error404", "Error");
            }
            await _service.Deleteasync(id);

            return RedirectToAction(nameof(Index));


        }
    }
}
