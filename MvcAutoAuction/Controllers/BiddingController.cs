using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.Controllers
{
    public class BiddingController : Controller
    {
        public ViewResult Index()
        {
            ViewData["memo"] = "Car Ad Expiry Date - 31st of July, 2012!";
            return View();
        }

        [HttpGet]
        public ViewResult BiddingForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Biddingform(Bid bid)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", bid);
            }
            else
            {
                // there is a validation error - redisplay the form
                return View();
            }
        }
    }
}