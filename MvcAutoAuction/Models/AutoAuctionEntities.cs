// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
using System.Data.Entity;

namespace MvcAutoAuction.Models
{
    public class AutoAuctionEntities : DbContext
    {
        public DbSet<Car>   Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Auto>  Autos { get; set; }                
        public DbSet<Cart>  Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}