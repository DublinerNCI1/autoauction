// using System;
using System.Collections.Generic;
// using System.Linq;
// using System.Web;

namespace MvcAutoAuction.Models
{
    public partial class Brand 
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public List<Car> Cars { get; set; }
    }
}