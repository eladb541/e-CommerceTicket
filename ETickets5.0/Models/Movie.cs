using ETickets5._0.Data.Base;
using ETickets5._0.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets5._0.Models
{
    public class Movie :IEntityBase
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description   { get; set; }
        public Double Price { get; set; }
        [Display(Name = "image")]
        public string ImageURL{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCatagory MovieCatagory { get; set; }


        public List<Actor_Movie> Actor_Movies { get; set; }

        public int CinimaId { get; set; }
        [ForeignKey("CinimaId")]
        public Cinima Cinima { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer  { get; set; }




    }
}
