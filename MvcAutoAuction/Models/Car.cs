using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range (0.01, 100000.00,
            ErrorMessage = "Price must be between 0.01 and 100000.00")]
        public decimal Price { get; set; }

        [DisplayName("Car Art URL")]
        [StringLength(1024)]
        public string CarArtUrl { get; set; }

        public virtual Brand Brand                      { get; set; }
        public virtual Auto Auto                        { get; set; }
        public virtual List<OrderDetail> OrderDetails   { get; set; }
    }
}