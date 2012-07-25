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
    public class CatalogManagerDAL
    {
        private AutoAuctionEntities db = new AutoAuctionEntities();

        public List<Car> indexCars()
        {
        var cars = db.Cars.Include(c => c.Brand).Include(c => c.Auto);
        var listcars = cars.ToList();
        return (listcars);

        }

        public Car details(int id)
        {
            Car car = db.Cars.Find(id);
            return (car);
        }

        public List<SelectList> create(){
        var BrandId = new SelectList(db.Brands, "BrandId", "Name");
        var AutoId = new SelectList(db.Autos, "AutoId", "Name");
        List<SelectList> list = new List<SelectList>();
        list.Add(BrandId);
        list.Add(AutoId);
        return(list);
        }

        public void createStore(Car car){
            
                db.Cars.Add(car);
                db.SaveChanges(); 
            }

        public Car edit(int id){

            Car car = db.Cars.Find(id);
            return(car);
        }
        public void editStore(Car car){
             db.Entry(car).State = EntityState.Modified;
             db.SaveChanges();

        }

        public Car delete(int id)
        {
            Car car = db.Cars.Find(id);
            return (car);
        }
        public void deleteConfirm(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
        }
        }
    }