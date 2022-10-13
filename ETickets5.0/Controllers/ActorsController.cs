using ETickets5._0.Data;
using ETickets5._0.Data.Services;
using ETickets5._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;

        }

        public async Task<IActionResult> Index()
        {

            var data = await _service.getallasync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Addasync(actor);
           return RedirectToAction(nameof(Index));    


        }
        public async Task<IActionResult>Details (int id)
        {
            var actorDetail = await _service.GetByIdasync(id);
            if (actorDetail == null) 
            {
                return View("NotFound");
            }
            else
            {
                return View(actorDetail);
            }

        }
        public async Task< IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetByIdasync(id);
            if (actorDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(actorDetail);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind(" Id,FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetail = await _service.GetByIdasync(id);
            if (actorDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(actorDetail);
            }

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var actorDetail = await _service.GetByIdasync(id);
            if (actorDetail == null)
            {
                return View("NotFound");
            }
            await _service.Deleteasync(id);
           
            return RedirectToAction(nameof(Index));


        }



    }
}
