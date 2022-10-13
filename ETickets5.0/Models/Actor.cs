using ETickets5._0.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Models
{
    public class Actor :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="profile pic is required")]
        [Display(Name ="profile picture ")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="the name must be between 3 to 5 chars")]
        [Display(Name = "full name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //relationships
        public List<Actor_Movie> Actor_Movies { get; set; }



    }
}
