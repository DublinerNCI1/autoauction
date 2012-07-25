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
    public class CheckoutDAL
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        public void addOrder(Order order)
        {
            catalogDB.Orders.Add(order);
            catalogDB.SaveChanges();
        }
    }
}