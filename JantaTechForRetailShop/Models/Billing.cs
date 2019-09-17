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
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
    }
}