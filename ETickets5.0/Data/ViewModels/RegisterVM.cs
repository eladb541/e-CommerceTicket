using System;
using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Data.ViewModels
{
    public class RegisterVM
    {


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Fullname { get; set; }

       
        [Display(Name ="email address")]
        [Required(ErrorMessage ="email address is required")]
        public string EmailAddress { get; set; }


        [Required]
        [StringLength(2000,ErrorMessage = "the password must cotain 8 characters at least ", MinimumLength =8 )]
        [DataType(DataType.Password) ]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords dont match")]
        public string ConfirmPassword { get; set; }

    }





}
