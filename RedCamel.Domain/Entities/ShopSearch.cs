using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Entities
{
    public class ShopSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public string Locality { get; set; }
        public string  Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double Distance { get; set; }
        public string Phone { get; set; }
        public string WebPage { get; set; }
        public string Email { get; set; }


    }
}
