using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Abstract
{
    public interface IProductRepository {
        IEnumerable<Product> Products { get; }
        IEnumerable<Category> Categories{ get; }
        IEnumerable<Subject> Subjects { get; }
        void SaveProduct(Product p);
    }
}
