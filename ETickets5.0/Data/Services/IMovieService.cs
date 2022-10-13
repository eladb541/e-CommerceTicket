using ETickets5._0.Data.Base;
using ETickets5._0.Data.ViewModels;
using ETickets5._0.Models;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> getmovieById(int Id);
        Task<NEWmoviedropdlistMV> GetNEWmoviedropdlistMValue();
        Task  Addnewmovieasync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
