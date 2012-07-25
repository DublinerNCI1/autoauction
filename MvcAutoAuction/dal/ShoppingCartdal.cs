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
    public class ShoppingCartDAL
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        public Car retrieveCar(int id){

        var addedCar = catalogDB.Cars
           .Single(car => car.CarId == id);
            return(addedCar);
        }

        public string getCarName(int id)
        {
            string carName = catalogDB.Carts
               .Single(item => item.RecordId == id).Car.Title;
            return (carName);
        }

      public Cart MatchingCarAndCart(string ShoppingCartId, Car car)
      {
        var cartItem = catalogDB.Carts.SingleOrDefault(
        c => c.CartId == ShoppingCartId
        && c.CarId == car.CarId);
        return(cartItem);
      }
       
       public void AddCartItem(Cart cartItem)
       {
       catalogDB.Carts.Add(cartItem);
      }

       public Cart GetTheCart(string ShoppingCartId, int id)
       {
           var cartItem = catalogDB.Carts.Single(
           cart => cart.CartId == ShoppingCartId
           && cart.RecordId == id);
           return (cartItem);
       }

       public void RemoveCartItem(Cart cartItem)
       {
           catalogDB.Carts.Remove(cartItem);
       }

       public void SaveCartChanges()
       {
           catalogDB.SaveChanges();
       }

       public void SaveChangestoCart()
       {

           catalogDB.SaveChanges();
       }
      public void RemoveAllItemsFromCart(string ShoppingCartId)
        {
        var cartItems = catalogDB.Carts.Where(cart => cart.CartId == ShoppingCartId);
        foreach (var cartItem in cartItems)
    {
        catalogDB.Carts.Remove(cartItem);
    }
        // Save changes
        catalogDB.SaveChanges();
    }
      
    }
}