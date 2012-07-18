// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcAutoAuction.Models
{        
    public class Bid
    {          
        
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
          ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your bid in figures, e.g. 1800.00")]
        public decimal PlaceBid { get; set; }        
    }
}