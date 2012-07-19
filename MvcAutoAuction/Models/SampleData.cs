using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcAutoAuction.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<AutoAuctionEntities>
    {
        protected override void Seed(AutoAuctionEntities context)
        {
            var brands = new List<Brand>
            {
                new Brand { Name = "BMW" },
                new Brand { Name = "Mercedes" },
                new Brand { Name = "VW" },
                new Brand { Name = "Audi" },
                new Brand { Name = "Ford" },
                new Brand { Name = "Fiat" },
                new Brand { Name = "Honda" },
                new Brand { Name = "Toyota" },
                new Brand { Name = "Mazda" },
                new Brand { Name = "Hyunday" }
            };

            var autos = new List<Auto>
            {
                new Auto { Name = "Van" },                
                new Auto { Name = "Convertible" },
                new Auto { Name = "Minibus" },
                new Auto { Name = "Pickup" },
                new Auto { Name = "Sedan" }
            };

            new List<Car>
            {
                new Car { Title = "VW.Passat=>2006.04", Brand = brands.Single(b => b.Name == "VW"), Price = 8995.00M, Auto = autos.Single(a => a.Name == "Sedan"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "VW.Golf=>2005.08", Brand = brands.Single(b => b.Name == "VW"), Price = 7995.00M, Auto = autos.Single(a => a.Name == "Sedan"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "VW.Beetle=>2007.02", Brand = brands.Single(b => b.Name == "VW"), Price = 6995.00M, Auto = autos.Single(a => a.Name == "Convertible"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "VW.Caravelle=>2005.11", Brand = brands.Single(b => b.Name == "VW"), Price = 6495.00M, Auto = autos.Single(a => a.Name == "Minibus"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "Mercedes.300=>2006.10", Brand = brands.Single(b => b.Name == "Mercedes"), Price = 7995.00M, Auto = autos.Single(a => a.Name == "Sedan"), CarArtUrl = "/Content/Images/placeholder.gif" },                
                new Car { Title = "Ford.Tranzit=>2006.05", Brand = brands.Single(b => b.Name == "Ford"), Price = 9995.00M, Auto = autos.Single(a => a.Name == "Van"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "Ford.Fiesta=>2003.12", Brand = brands.Single(b => b.Name == "Ford"), Price = 2995.00M, Auto = autos.Single(a => a.Name == "Sedan"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "Toyota.Ultima=>2005.02", Brand = brands.Single(b => b.Name == "Toyota"), Price = 8995.00M, Auto = autos.Single(a => a.Name == "Pickup"), CarArtUrl = "/Content/Images/placeholder.gif" },
                new Car { Title = "Audi.Quattro=>2005.12", Brand = brands.Single(b => b.Name == "Audi"), Price = 7495.00M, Auto = autos.Single(a => a.Name == "Pickup"), CarArtUrl = "/Content/Images/placeholder.gif" },                
                new Car { Title = "Audi.Coupe=>2008.05", Brand = brands.Single(b => b.Name == "Audi"), Price = 8495.00M, Auto = autos.Single(a => a.Name == "Sedan"), CarArtUrl = "/Content/Images/placeholder.gif" },
                    
                          
            }.ForEach(a => context.Cars.Add(a));
        }
    }
}