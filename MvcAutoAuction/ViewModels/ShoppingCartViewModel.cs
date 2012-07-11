using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}