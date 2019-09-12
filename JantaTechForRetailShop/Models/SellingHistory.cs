using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JantaTechForRetailShop.Models
{
    public class SellingHistory
    {
        public int Id { get; set; }
        public Billing Billing { get; set; }
        public int BillingId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}