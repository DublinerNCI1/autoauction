using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcAutoAuction.Models
{
    [Bind(Exclude = "BidId")]
    public partial class Bid
    {
        [ScaffoldColumn(false)]
        public int BidId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime BidDate { get; set; }

        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Your Bid in digits")]
        [DisplayName("Your Bid")]        
        public decimal BidAmount { get; set; }   
        
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }        
    }
}

