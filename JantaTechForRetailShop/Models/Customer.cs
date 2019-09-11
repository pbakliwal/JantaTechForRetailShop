using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JantaTechForRetailShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Mobile Number")]
        [Required]
        [RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Entered Mobile No is not valid.")]
        public string PhoneNo { get; set; }
    }
}