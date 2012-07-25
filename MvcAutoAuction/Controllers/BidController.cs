using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.Controllers
{
    [Authorize]
    public class BidController : Controller
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();
        // const string SecurityPass = "Willcontactifbidsuccessful";

        //
        // GET: /Bid/Bidding Form

        public ActionResult BiddingForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BiddingForm (FormCollection values)
        {
        
          return View("BiddingSummary");            
        }

        public ActionResult BiddingSummary(Bid bid)
        {
            return View("BiddingSummary", bid);            
        }
    }
}

