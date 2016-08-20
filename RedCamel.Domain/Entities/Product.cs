using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Entities
{
    public enum ProductCondition
    {
        NearMint = 1,
        VeryGood=2,
        Good=3,
        Fair=4,
        Poor=5
    }

    public enum CategoryEnum
    {
        All = 1,
        TPB = 2,
        Comic = 3,
        Hardback = 4
    }

    public enum PublisherEnum
    {
        Marvel = 1,
        DC = 2,
        Image = 3
    }

    public class Product {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        public ProductCondition Condition { get; set; }
        public PublisherEnum Publisher { get; set; }
        public string Image1Name { get; set; }
        public string Image1Path { get; set; }
        public string Image2Name { get; set; }
        public string Image2Path { get; set; }
        public int Subject { get; set; }
    }
}
