using ETickets5._0.Models;
using System.Collections.Generic;

namespace ETickets5._0.Data.ViewModels
{
    public class NEWmoviedropdlistMV
    {
        public NEWmoviedropdlistMV()
        {
            producers = new List<Producer>();
            cinima = new List<Cinima>();
            actors = new List<Actor>();
        }

        public List<Producer> producers { set; get; }
        public List<Cinima> cinima { set; get; }
        public List<Actor> actors { set; get; }



    }
}
