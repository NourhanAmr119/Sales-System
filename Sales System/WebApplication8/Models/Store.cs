using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication8.Models
{
    public class Store
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Store_Name { get; set; }
        [Required]
        public string Region { get; set; }
        [Range(5, 500)]
        public int Quantity_saled { get; set; }
        [Required]
        public decimal Revenue { get; set; }
        [Required]
        public string Product_Name { get; set; }

    }
}

