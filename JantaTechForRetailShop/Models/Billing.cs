using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JantaTechForRetailShop.Models
{
    public class Billing
    {
        public int Id { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
    }
}