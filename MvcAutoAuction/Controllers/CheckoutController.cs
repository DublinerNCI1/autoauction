using System;
using System.Linq;
using System.Web.Mvc;
using MvcAutoAuction.Models;
using MvcAutoAuction.logic;
using MvcAutoAuction.dal;

namespace MvcAutoAuction.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();
        const string PromoCode = "Theplacetobe";

        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AdressAndPayment

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }

                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    /*catalogDB.Orders.Add(order);
                    catalogDB.SaveChanges();*/

                    CheckoutDAL dal = new CheckoutDAL();
                    dal.addOrder(order);

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }

            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {

            // Validate customer owns this order
            bool isValid = catalogDB.Orders.Any(
            o => o.OrderId == id &&
            o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}

