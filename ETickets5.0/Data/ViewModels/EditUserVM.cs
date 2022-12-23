using System;
using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Data.ViewModels
{
    public class EditUserVM
    {


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Fullname { get; set; }

       
        [Display(Name ="email address")]
        [Required(ErrorMessage ="email address is required")]
        public string EmailAddress { get; set; }

       
        public string EUMVid { get; set; }
      

    }





}
