using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedCamel.WebUI.Controllers.API
{
    public class api_ProductController : ApiController
    {
        private IProductRepository repository;

        public api_ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: api/api_Product
        public List<Product> Get()
        {

            var products = repository.Products.ToList<Product>();

            return products;
        }

        // GET: api/api_Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/api_Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/api_Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/api_Product/5
        public void Delete(int id)
        {
        }
    }
}
