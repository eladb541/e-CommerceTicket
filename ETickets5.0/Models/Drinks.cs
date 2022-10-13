using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Models
{
    public class Drinks
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        


    }
}
