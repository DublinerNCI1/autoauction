using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.Controllers
{ 
    [Authorize(Roles = "adminci")]
    public class CatalogManagerController : Controller
    {
        private AutoAuctionEntities db = new AutoAuctionEntities();

        //
        // GET: /CatalogManager/

        public ViewResult Index()
        {
            var cars = db.Cars.Include(c => c.Brand).Include(c => c.Auto);
            return View(cars.ToList());
        }

        //
        // GET: /CatalogManager/Details/5

        public ViewResult Details(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // GET: /CatalogManager/Create

        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name");
            return View();
        } 

        //
        // POST: /CatalogManager/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);
            return View(car);
        }
        
        //
        // GET: /CatalogManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Car car = db.Cars.Find(id);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);
            return View(car);
        }

        //
        // POST: /CatalogManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);
            return View(car);
        }

        //
        // GET: /CatalogManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // POST: /CatalogManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}