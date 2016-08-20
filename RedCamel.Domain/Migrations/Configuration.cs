namespace RedCamel.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    //Enable-Migrations
    //add-migration Initial
    //update-database -Verbose


    internal sealed class Configuration : DbMigrationsConfiguration<RedCamel.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RedCamel.Domain.Concrete.EFDbContext context)
        {


            /*
            var images = new List<Image>
            {
                new Image {  FileName= "~/App_Data/uploads/Image1", Name="FF Vol 1 Img 1", ProductID=1 },
                new Image {  FileName= "~/App_Data/uploads/Image2", Name="FF Vol 1 Img 2", ProductID=1 },
            };

            images.ForEach(p => context.Images.Add(p));
            context.SaveChanges();
            */


            
            var products = new List<Product>
            {
                new Product {  Name="FF Vol 1", Category= CategoryEnum.Hardback, Condition= ProductCondition.NearMint, Price=55M  }
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
            



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
