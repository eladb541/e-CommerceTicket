using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Data.ViewModels
{
    public class LoginVM
    {

        [Display(Name ="email address")]
        [Required(ErrorMessage ="email address is required")]
        public string EmailAddress { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }





}
