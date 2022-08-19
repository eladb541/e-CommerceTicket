using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets5._0.Models
{
    public class Cinima
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }


        public List<Movie> Movies { get; set; }

    }
} 
