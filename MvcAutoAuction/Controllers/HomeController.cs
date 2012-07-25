using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcAutoAuction.Models;
using MvcAutoAuction.dal;

namespace MvcAutoAuction.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        public ActionResult Index()
        {
            /*if (catalogDB.Database.Exists())
            {*/

                //  Get most popular cars
                HomeDAL dal = new HomeDAL();
                var cars = dal.GetTopSellingCars(5);

                return View(cars);

            /*}*/
            /*else catalogDB.Database.Create();
            return View();*/
        }
        
        /*private List<Car> GetTopSellingCars(int count)
        {
            // Group the order details by car and return
            // the cars with the highest count

            return catalogDB.Cars
                 .OrderByDescending(c => c.OrderDetails.Count())
                 .Take(count)
                 .ToList();
        } */             
    }
}
    

