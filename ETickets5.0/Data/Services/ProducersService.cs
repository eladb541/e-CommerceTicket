using ETickets5._0.Data.Base;
using ETickets5._0.Models;

namespace ETickets5._0.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
                
        }



    }
}
