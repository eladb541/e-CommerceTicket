using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }



    }
}
