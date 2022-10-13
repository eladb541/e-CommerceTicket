using ETickets5._0.Data.Base;
using ETickets5._0.Models;

namespace ETickets5._0.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinima>,ICinemaService
    {
        public CinemaService(AppDbContext context):base(context)
        {

        }

    }
}
