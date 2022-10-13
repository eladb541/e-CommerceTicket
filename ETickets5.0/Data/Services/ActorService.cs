using ETickets5._0.Data.Base;
using ETickets5._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorsService
    {
       
        public ActorService(AppDbContext context) : base(context) { }
       

    }
}
