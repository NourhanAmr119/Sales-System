using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication8.Models
{
    public class Sales
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Supplier { get; set; }
        [Range(5, 500)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date_of_purchase { get; set; }
       
    }
}
