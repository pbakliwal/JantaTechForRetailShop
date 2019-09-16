using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JantaTechForRetailShop.Models
{
    public class TempProduct
    {
        public int Id { get; set; }
        
        public string Category { get; set; }
        
        public string BarCodeId { get; set; }
        
        public string Colour { get; set; }
        
        public int Price { get; set; }
        
        public string Size { get; set; }
        
        public int Quantity { get; set; }
        
        public string Brand { get; set; }
    }
}