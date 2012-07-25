using System.Linq;
using System.Web.Mvc;
using MvcAutoAuction.Models;
using MvcAutoAuction.ViewModels;
using MvcAutoAuction.logic;
using MvcAutoAuction.dal;

namespace MvcAutoAuction.Controllers
{
    public class ShoppingCartController : Controller
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
        {
            CartItems = cart.GetCartItems(),
            CartTotal = cart.GetTotal()
        };
            // Return the view
            return View(viewModel);
        }
            //
            // GET: /Catalog/AddToCart/5
            public ActionResult AddToCart(int id)
        {
            // Retrieve the car from the database
           // var addedCar = catalogDB.Cars
           // .Single(car => car.CarId == id);
            // Add it to the shopping cart
            ShoppingCartDAL dal = new ShoppingCartDAL();
            var addedCar = dal.retrieveCar(id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedCar);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
            //
            // AJAX: /ShoppingCart/RemoveFromCart/5

            [HttpPost]
            public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Get the name of the car to display confirmation
            /*string carName = catalogDB.Carts
            .Single(item => item.RecordId == id).Car.Title;*/

            ShoppingCartDAL dal = new ShoppingCartDAL();
            string carName = dal.getCarName(id);


            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
        {
            Message = Server.HtmlEncode(carName) +
          " has been removed from your shopping cart.",
            CartTotal = cart.GetTotal(),
            CartCount = cart.GetCount(),
            ItemCount = itemCount,
            DeleteId = id
        };
            return Json(results);
        }
            //
            // GET: /ShoppingCart/CartSummary
            [ChildActionOnly]
            public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
        

    

