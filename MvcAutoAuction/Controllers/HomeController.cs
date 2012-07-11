// using System;
using System.Collections.Generic;
using System.Linq;
// using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        public ActionResult Index()
        {
            // Get most popular cars
            var cars = GetTopSellingCars(5);
            return View(cars);
        }

        private List<Car> GetTopSellingCars(int count)
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
