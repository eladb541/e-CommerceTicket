using ETickets5._0.Data.Base;
using ETickets5._0.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets5._0.Models
{
    public class NewMovieVM
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description   { get; set; }
         [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(1, Double.PositiveInfinity,ErrorMessage ="the price must be at least 1 nis")]
        public Double Price { get; set; }
        [Display(Name = "image")]
        [Required(ErrorMessage = "image is required")]
        public string ImageURL{ get; set; }
        [Display(Name = "StartDate")]
        [Required(ErrorMessage = "StartDate")]
        public DateTime StartDate { get; set; }
        
       
        [Display(Name = "endDate")]
        [Required(ErrorMessage = "endDate is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "select Category")]
        [Required(ErrorMessage = "Category is required")]

        public MovieCatagory MovieCatagory { get; set; }

        [Display(Name = "select a an actor")]
        [Required(ErrorMessage = "actor is required")]

        public List<int> ActorsIds { get; set; }
        [Display(Name = "select a  cinema")]
        [Required(ErrorMessage = "cinema is required")]

        public int CinimaId { get; set; }
        [Display(Name = "select a producer")]
        [Required(ErrorMessage = "producer is required")]

        public int producerId  { get; set; }




    }
}
