﻿using System;
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
        public string BarCodeId { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Cost Price")]
        public int CostPrice { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}