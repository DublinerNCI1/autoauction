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
                new Car { Title = "Passat=>2006", Brand = brands.Single(b => b.Name == "VW"), Price = 8995.00M, Auto = autos.Single(a => a.Name == "Sedan"), Image = "/Content/Images/passat.JPG" },
                new Car { Title = "Golf=>2005", Brand = brands.Single(b => b.Name == "VW"), Price = 7995.00M, Auto = autos.Single(a => a.Name == "Sedan"), Image = "/Content/Images/golf.JPG" },
                new Car { Title = "Beetle=>2007", Brand = brands.Single(b => b.Name == "VW"), Price = 6995.00M, Auto = autos.Single(a => a.Name == "Convertible"), Image = "/Content/Images/beetle.JPG" },
                new Car { Title = "Caravelle=>2005", Brand = brands.Single(b => b.Name == "VW"), Price = 6495.00M, Auto = autos.Single(a => a.Name == "Minibus"), Image = "/Content/Images/caravelle.JPG" },
                new Car { Title = "SL320=>2006", Brand = brands.Single(b => b.Name == "Mercedes"), Price = 7995.00M, Auto = autos.Single(a => a.Name == "Sedan"), Image = "/Content/Images/mercedes.JPG" },                
                new Car { Title = "Tranzit=>2006", Brand = brands.Single(b => b.Name == "Ford"), Price = 9995.00M, Auto = autos.Single(a => a.Name == "Van"), Image = "/Content/Images/tranzit.JPG" },
                new Car { Title = "Fiesta=>2003", Brand = brands.Single(b => b.Name == "Ford"), Price = 2995.00M, Auto = autos.Single(a => a.Name == "Sedan"), Image = "/Content/Images/fiesta.JPG" },
                new Car { Title = "Camry=>2005", Brand = brands.Single(b => b.Name == "Toyota"), Price = 8995.00M, Auto = autos.Single(a => a.Name == "Pickup"), Image = "/Content/Images/toyota.JPEG" },
                new Car { Title = "Quattro=>2005", Brand = brands.Single(b => b.Name == "Audi"), Price = 7495.00M, Auto = autos.Single(a => a.Name == "Pickup"), Image = "/Content/Images/quattro.JPG" },                
                new Car { Title = "TT=>2008", Brand = brands.Single(b => b.Name == "Audi"), Price = 8495.00M, Auto = autos.Single(a => a.Name == "Sedan"), Image = "/Content/Images/coupe.JPG" },
                    
                          
            }.ForEach(a => context.Cars.Add(a));
        }
    }
}