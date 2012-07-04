using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAutoAuction.Models
{
    public partial class ShoppingCart
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
    {
        var cart = new ShoppingCart();
        cart.ShoppingCartId = cart.GetCartId(context);
        return cart;
    }
    // Helper method to simplify shopping cart calls
    public static ShoppingCart GetCart(Controller controller)
    {
        return GetCart(controller.HttpContext);
    }
    public void AddToCart(Car car)
    {
        // Get the matching cart and car instances
        var cartItem = catalogDB.Carts.SingleOrDefault(
        c => c.CartId == ShoppingCartId
        && c.CarId == car.CarId);
        if (cartItem == null)
    {
        // Create a new cart item if no cart item exists
        cartItem = new Cart
    {
        CarId = car.CarId,
        CartId = ShoppingCartId,
        Count = 1,
        DateCreated = DateTime.Now
    };
        catalogDB.Carts.Add(cartItem);
    }
        else
    {
        // If the item does exist in the cart, then add one to the quantity
        cartItem.Count++;
    }
        // Save changes
        catalogDB.SaveChanges();
    }

        public int RemoveFromCart(int id)
    {
        // Get the cart
        var cartItem = catalogDB.Carts.Single(
        cart => cart.CartId == ShoppingCartId
        && cart.RecordId == id);

        int itemCount = 0;
        if (cartItem != null)
    {
        if (cartItem.Count > 1)
    {
        cartItem.Count--;
        itemCount = cartItem.Count;
    }
        else
    {
        catalogDB.Carts.Remove(cartItem);
    }
        // Save changes
        catalogDB.SaveChanges();
    }
        return itemCount;
    }
        public void EmptyCart()
    {
        var cartItems = catalogDB.Carts.Where(cart => cart.CartId == ShoppingCartId);
        foreach (var cartItem in cartItems)
    {
        catalogDB.Carts.Remove(cartItem);
    }
        // Save changes
        catalogDB.SaveChanges();
    }
        public List<Cart> GetCartItems()
    {
        return catalogDB.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
    }
        public int GetCount()
    {
        // Get the count of each item in the cart and sum them up
        int? count = (from cartItems in catalogDB.Carts
        where cartItems.CartId == ShoppingCartId
        select (int?)cartItems.Count).Sum();
        // Return 0 if all entries are null
        return count ?? 0;
    }
        public decimal GetTotal()
    {
        // Multiply car price by count of that album to get
        // the current price for each of those cars in the cart
        // sum all album price totals to get the cart total

        decimal? total = (from cartItems in catalogDB.Carts
        where cartItems.CartId == ShoppingCartId
        select (int?)cartItems.Count * cartItems.Car.Price).Sum();
        return total ?? decimal.Zero;
    }
        public int CreateOrder(Order order)
    {
        decimal orderTotal = 0;
        var cartItems = GetCartItems();
        // Iterate over the items in the cart, adding the order details for each
        foreach (var item in cartItems)
    {
        var orderDetail = new OrderDetail
    {
        CarId = item.CarId,
        OrderId = order.OrderId,
        UnitPrice = item.Car.Price,
        Quantity = item.Count
    };
        // Set the order total of the shopping cart
        orderTotal += (item.Count * item.Car.Price);
        catalogDB.OrderDetails.Add(orderDetail);
    }
        // Set the order's total to the orderTotal count
        order.Total = orderTotal;
        // Save the order
        catalogDB.SaveChanges();
        // Empty the shopping cart
        EmptyCart();
        // Return the OrderId as the confirmation number
        return order.OrderId;
    }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
    {
        if (context.Session[CartSessionKey] == null)
    {
        if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
    {
        context.Session[CartSessionKey] = context.User.Identity.Name;
    }
        else
    {
        // Generate a new random GUID using System.Guid class

        Guid tempCartId = Guid.NewGuid();
        // Send tempCartId back to client as a cookie
        context.Session[CartSessionKey] = tempCartId.ToString();
    }
    }
        return context.Session[CartSessionKey].ToString();
    }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
    {
    var shoppingCart = catalogDB.Carts.Where(c => c.CartId == ShoppingCartId);
    foreach (Cart item in shoppingCart)
    {
        item.CartId = userName;
    }
    catalogDB.SaveChanges();
    }
  }
}
    
