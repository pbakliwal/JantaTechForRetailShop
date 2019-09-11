using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JantaTechForRetailShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Display(Name ="Bar Code")]
        [Required]
        public string BarCodeId { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}