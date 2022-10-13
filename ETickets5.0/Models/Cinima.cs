using ETickets5._0.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets5._0.Models
{
    public class Cinima :IEntityBase
    { 
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " pic is required")]
        [Display(Name = "logo")]
        public string Logo { get; set; }
        [Required(ErrorMessage = " name is required")]
        [Display(Name = "name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        public List<Movie> Movies { get; set; }

    }
} 
