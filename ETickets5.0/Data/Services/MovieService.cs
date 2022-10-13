using ETickets5._0.Data.Base;
using ETickets5._0.Data.ViewModels;
using ETickets5._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Addnewmovieasync(NewMovieVM data)
        {
            var newMOvie = new Movie()
            {

                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinimaId = data.CinimaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCatagory = data.MovieCatagory,
                ProducerId = data.producerId,
            };
            await _context.Movies.AddAsync(newMOvie);
            await _context.SaveChangesAsync();

            foreach (var actorid in data.ActorsIds)
            {


                var newactormovie = new Actor_Movie()
                {

                    MovieId = newMOvie.Id,
                    ActotId = actorid

                };
                await _context.Actor_Movies.AddAsync(newactormovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> getmovieById(int Id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinima)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == Id);

            return movieDetails;
        }

        public async Task<NEWmoviedropdlistMV> GetNEWmoviedropdlistMValue()
        {
            var response = new NEWmoviedropdlistMV();

            response.actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();
            response.cinima = await _context.Cinimas.OrderBy(n => n.Name).ToListAsync();





            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbMovie != null)
            {

                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinimaId = data.CinimaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCatagory = data.MovieCatagory;
                dbMovie.ProducerId = data.producerId;
                await _context.SaveChangesAsync();
            }
            var existingActorsDB = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actor_Movies.RemoveRange(existingActorsDB);
            await _context.SaveChangesAsync();



            foreach (var actorid in data.ActorsIds)
            {


                var newactormovie = new Actor_Movie()
                {

                    MovieId = data.Id,
                    ActotId = actorid

                };
                await _context.Actor_Movies.AddAsync(newactormovie);
            }
            await _context.SaveChangesAsync();
        } 
    }
}
