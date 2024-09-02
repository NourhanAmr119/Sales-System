using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public int Order_Number { get; set; }
        [Required]
        public string Payment_Strategy { get; set; }
        [Range(5, 500)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Store_Name { get; set; }
        [Required]
        public string Product_Name { get; set; }

    }
}
