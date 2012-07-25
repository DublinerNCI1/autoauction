﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoAuction.Models;

namespace MvcAutoAuction.dal
{
    public class CatalogDAL
    {
        // protected AccessDB db = new AccessDB();

        AutoAuctionEntities catalogDB = new AutoAuctionEntities();

        //add brands
     /*   public bool addBrandToDb(Brand b)
        {
            Brand b = new Brand();

        b=catalogDB.Brands.Add(b);
          if (b is Brand)

          {
              catalogDB.SaveChanges();

            return true;
          }
            return false;
          }


        brands */

        public List<Brand> BrandsToList()
        {
            var brands = catalogDB.Brands.ToList();
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

            };
            return (brands);
        }



    public Brand browseBrand(string brand){
        var brandModel = catalogDB.Brands.Include("Cars")
               .Single(b => b.Name == brand);
        return (brandModel);
    }


    public Car findCarsbyID(int id)
    {
    var car = catalogDB.Cars.Find(id);
    return(car);
    }

    public List<Brand> brandsToListing()
    {
        var brands = catalogDB.Brands.ToList();
        return (brands);
    }


    }

}