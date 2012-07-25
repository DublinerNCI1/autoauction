using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.dal
{
    public class HomeDAL
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();
        public List<Car> GetTopSellingCars(int count)
        {
            // Group the order details by car and return
            // the cars with the highest count

            return catalogDB.Cars
                 .OrderByDescending(c => c.OrderDetails.Count())
                 .Take(count)
                 .ToList();
        }
    }
}