using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();


        public IEnumerable<Product> Products
        {
           get {
                return context.Products; //.Include("Images");
            }
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories; //.Include("Images");
            }
        }

        public IEnumerable<Subject> Subjects
        {
            get
            {
                return context.Subjects;
            }
        }

        public void SaveProduct(Product product) {
            if (product.ID == 0)
            {
                context.Products.Add(product); }
            else
            { Product dbEntry = context.Products.Find(product.ID);
                if (dbEntry != null) {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.Image1Name = product.Image1Name;
                    dbEntry.Image1Path = product.Image1Path;
                    dbEntry.Image2Name = product.Image2Name;
                    dbEntry.Image2Path = product.Image2Path;
                }
            }
            context.SaveChanges(); }
    }
}
