using ETickets5._0.Data;
using ETickets5._0.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ETickets5._0.Models;


namespace ETickets5._0.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {

            _service = service;
        }
        public async Task<IActionResult> Index()

        {
            var allmovies = await _service.getallasync(n => n.Cinima);
            return View(allmovies);
        }
        public async Task<IActionResult> Filter(string searchString)

        {
            var allmovies = await _service.getallasync(n => n.Cinima);
           if (!string.IsNullOrEmpty(searchString))
            {
                var FilteredResult= allmovies.Where(n => n.Name.Contains(searchString)|| n.Description.Contains(searchString)).ToList();
                return View("Index", FilteredResult);
            }

           return View("Index",allmovies);

        }

        public async Task<IActionResult> Details(int id)
        {
            var moviedetails = await _service.getmovieById(id);
            if (moviedetails==null)
           
            {
                return RedirectToAction("Error404", "Error");
            }
            
            
            
            return View(moviedetails);  
           
        }
        public async Task<IActionResult> Create()
        {
            var moviedropdownlist = await _service.GetNEWmoviedropdlistMValue();
            ViewBag.CinemaId = new SelectList(moviedropdownlist.cinima, "Id", "Name");
            ViewBag.ProducerId = new SelectList(moviedropdownlist.producers, "Id", "FullName");
            ViewBag.ActorIds = new SelectList(moviedropdownlist.actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {

            if (!ModelState.IsValid)
            {
                var moviedropdownlist = await _service.GetNEWmoviedropdlistMValue();
                ViewBag.CinemaId = new SelectList(moviedropdownlist.cinima, "Id", "Name");
                ViewBag.ProducerId = new SelectList(moviedropdownlist.producers, "Id", "FullName");
                ViewBag.ActorIds = new SelectList(moviedropdownlist.actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.Addnewmovieasync(movie);
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var moviedetails=await _service.getmovieById(id);
            if (moviedetails == null)
            {
                return RedirectToAction("Error404", "Error");
            }


            var response = new NewMovieVM()
            {
                Id = moviedetails.Id,
                Name = moviedetails.Name,
                Description = moviedetails.Description,
                Price = moviedetails.Price,
                ImageURL = moviedetails.ImageURL,
                MovieCatagory = moviedetails.MovieCatagory,
                CinimaId = moviedetails.CinimaId,
                producerId = moviedetails.ProducerId,
                StartDate=moviedetails.StartDate,
                EndDate=moviedetails.EndDate,
                ActorsIds = moviedetails.Actor_Movies.Select(n => n.ActotId).ToList(),
            };


            var moviedropdownlist = await _service.GetNEWmoviedropdlistMValue();
            ViewBag.CinemaId = new SelectList(moviedropdownlist.cinima, "Id", "Name");
            ViewBag.ProducerId = new SelectList(moviedropdownlist.producers, "Id", "FullName");
            ViewBag.ActorIds = new SelectList(moviedropdownlist.actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return RedirectToAction("Error404", "Error");
            }


            if (!ModelState.IsValid)
            {
                var moviedropdownlist = await _service.GetNEWmoviedropdlistMValue();
                ViewBag.CinemaId = new SelectList(moviedropdownlist.cinima, "Id", "Name");
                ViewBag.ProducerId = new SelectList(moviedropdownlist.producers, "Id", "FullName");
                ViewBag.ActorIds = new SelectList(moviedropdownlist.actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.UpdateMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }

        }





    }
}
  


            

  

