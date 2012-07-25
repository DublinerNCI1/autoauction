using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;
using MvcAutoAuction.dal;

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
            /*var cars = db.Cars.Include(c => c.Brand).Include(c => c.Auto);
            return View(cars.ToList());*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            var cars = dal.indexCars();
            return View(cars);
        }

        //
        // GET: /CatalogManager/Details/5

        public ViewResult Details(int id)
        {
            /*Car car = db.Cars.Find(id);*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            Car car = dal.details(id);
            return View(car);
        }

        //
        // GET: /CatalogManager/Create

        public ActionResult Create()
        {
            /*ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name");*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            List<SelectList> id = dal.create();
            
            ViewBag.BrandId = id[0];
            ViewBag.AutoId = id[1];
 
            return View();
        } 

        //
        // POST: /CatalogManager/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                CatalogManagerDAL dal = new CatalogManagerDAL();
                dal.createStore(car);
                return RedirectToAction("Index");  
            }

           /* ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);
            return View(car);*/
            CatalogManagerDAL dal2 = new CatalogManagerDAL();
            List<SelectList> id = dal2.create();

            ViewBag.BrandId = id[0];
            ViewBag.AutoId = id[1];

            return View(car);
        }
        
        //
        // GET: /CatalogManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            /*Car car = db.Cars.Find(id);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            Car car = dal.edit(id);

            CatalogManagerDAL dal2 = new CatalogManagerDAL();
            List<SelectList> id2 = dal2.create();

            ViewBag.BrandId = id2[0];
            ViewBag.AutoId = id2[1];
            
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
               /* CatalogManagerDAL dal = new CatalogManagerDAL();
                dal.editStore(car);
                return RedirectToAction("Index");*/
            }
            /*ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            ViewBag.AutoId = new SelectList(db.Autos, "AutoId", "Name", car.AutoId);*/

            CatalogManagerDAL dal2 = new CatalogManagerDAL();
            List<SelectList> id = dal2.create();

            ViewBag.BrandId = id[0];
            ViewBag.AutoId = id[1];

            return View(car);
        }

        //
        // GET: /CatalogManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            
            /*Car car = db.Cars.Find(id);*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            Car car = dal.delete(id);
            return View(car);
        }

        //
        // POST: /CatalogManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            /*Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();*/
            CatalogManagerDAL dal = new CatalogManagerDAL();
            dal.deleteConfirm(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}