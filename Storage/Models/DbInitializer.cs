﻿// Based on the Pluralsight course
using Storage.Data;

namespace Storage.Models
{
    public static class DbInitializer
    {
        private static Product[] SeedProducts => [
            new Product { Name="Melltorp" , Price= 595, Orderdate = new DateTime(2024, 4, 9, 15, 05, 0), Category="Furniture"  , Shelf="34", Count= 5, Description="Table, white" },
            new Product { Name="Matchspel", Price=2295, Orderdate = new DateTime(2024, 4, 9, 15, 02, 0), Category="Furniture"  , Shelf="21", Count= 4, Description="Gaming chair, Bomstad black" },
            new Product { Name="Gladelig" , Price= 249, Orderdate = new DateTime(2024, 4, 9, 14, 45, 0), Category="Kitchenware", Shelf="48", Count=20, Description="Plate, grey" },
            new Product { Name="Lagan"    , Price=2495, Orderdate = new DateTime(2024, 4, 9, 16, 20, 0), Category="Appliances" , Shelf="08", Count= 3, Description="Fridge with freezer compartment, freestanding/white" },
            new Product { Name="Lohals"   , Price=1495, Orderdate = new DateTime(2024, 4, 9, 16, 10, 0), Category="Rugs"       , Shelf="49", Count=10, Description="Rug, flatwoven, natural" },
            new Product { Name="Säbövik"  , Price=3795, Orderdate = new DateTime(2024, 4, 9, 17, 25, 0), Category="Beds"       , Shelf="54", Count= 2, Description="Divan bed, firm/Vissle grey" }
        ];

        //private static string[] SeedCategories => [
        //    "Furniture", "Kitchenware", "Appliances", "Rugs", "Beds"
        //];

        public static void Seed(IApplicationBuilder app)
        {
            StorageContext context
                = app.ApplicationServices.CreateScope()
                    .ServiceProvider.GetRequiredService<StorageContext>();

            //if (!context.Category.Any())
            //{
            //    context.AddRange(SeedCategories);
            //}
            
            if (!context.Product.Any())
            {
                context.AddRange(SeedProducts);
            }

            context.SaveChanges();
        }
    }
}
