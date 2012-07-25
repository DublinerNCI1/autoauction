using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;
using MvcAutoAuction.dal;

namespace MvcAutoAuction.Controllers
{
    public class CatalogController : Controller
    {
        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        //
        // GET: /Catalog/        

        public ActionResult Index()
        {
           /* var brands = catalogDB.Brands.ToList();
            {
                new Brand { Name = "BMW" };
                new Brand { Name = "Mercedes" };
                new Brand { Name = "VW" };
                new Brand { Name = "Audi" };
                new Brand { Name = "Ford" };
                new Brand { Name = "Fiat" };
                new Brand { Name = "Honda" };
                new Brand { Name = "Toyota" };
                new Brand { Name = "Mazda" };
                new Brand { Name = "Hyunday" };
            };*/

            CatalogDAL dal = new CatalogDAL();
            var brands = dal.BrandsToList();
            return View(brands);
            
        }


        //
        // GET: /Catalog/Browse?brand=BMW

        public ActionResult Browse(string brand)
        {
            //Retrieve Brand and its Associated Cars from database
            /*var brandModel = catalogDB.Brands.Include("Cars")
                .Single(b => b.Name == brand);*/
            CatalogDAL dal = new CatalogDAL();
            var brandModel = dal.browseBrand(brand); 
            return View(brandModel); ;
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(int id)
        {
           /* var car = catalogDB.Cars.Find(id);*/
            CatalogDAL dal = new CatalogDAL();
            var car = dal.findCarsbyID(id);

            return View(car);
        }


        //
        // GET: /Catalog/BrandMenu

        [ChildActionOnly]
        public ActionResult BrandMenu()
        {
            /*var brands = catalogDB.Brands.ToList();*/

            CatalogDAL dal = new CatalogDAL();
            var brands = dal.BrandsToList();

            return PartialView(brands);
        }              
    }
}


