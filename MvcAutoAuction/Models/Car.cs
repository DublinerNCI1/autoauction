// using System;
// using System.Linq;
// using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MvcAutoAuction.Models
{
    [Bind(Exclude = "CarId")]
    public class Car
    {
        [ScaffoldColumn(false)]
        public int CarId { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }

        [DisplayName("Auto")]
        public int AutoId { get; set; }

        [Required(ErrorMessage = "Car Title is required")]
        [StringLength(16)]
        public string Title { get; set; }
                
        [Required(ErrorMessage = "Price")]
        [Range(100.00, 100000.00,
            ErrorMessage = "Price must be between 100.00 and 100000.00")]
        public decimal Price { get; set; }

        // [Required(ErrorMessage = "Introductory Price")]
        // [StringLength(160)]
        // public string IntroPrice { get; set; }

        // [Required(ErrorMessage = "Expiry Date")]
        // [StringLength(160)]
        // public string ExpiryDate { get; set; }

        
        // [Required(ErrorMessage = "Introductory Price is required")]
        // [Range(100.00, 100000.00,
        //    ErrorMessage = "Price must be between 100.00 and 100000.00")]
        // public decimal IntroPrice { get; set; }        

        // [DisplayName("Expiry Date")]
        // [Required(ErrorMessage = "Vehicle Ad Expiry Date")]
        // [DisplayFormat(DataFormatString = "{0:ddd, dd MMM yyyy}", ApplyFormatInEditMode = true)]
        // public string ExpiryDate { get; set; }          
                       
        [DisplayName("Image URL")]
        [StringLength(1024)]
        public string Image { get; set; }

        public virtual Brand Brand                      { get; set; }
        public virtual Auto Auto                        { get; set; }
        public virtual List<OrderDetail> OrderDetails   { get; set; }
    }    
}