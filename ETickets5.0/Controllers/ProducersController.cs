using ETickets5._0.Data;
using ETickets5._0.Data.Services;
using ETickets5._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()

        {
            var allProducers = await _service.getallasync();
            return View(allProducers);
        }
        public async Task<IActionResult> Details(int id)
        {
            var producerDetail = await _service.GetByIdasync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(producerDetail);
            }
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]  Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Addasync(producer);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail = await _service.GetByIdasync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(producerDetail);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind(" Id,FullName, ProfilePictureURL, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetail = await _service.GetByIdasync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(producerDetail);
            }

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetail = await _service.GetByIdasync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            await _service.Deleteasync(id);

            return RedirectToAction(nameof(Index));


        }

    }
}
