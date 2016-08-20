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
    public class ShopSearchController : ApiController
    {
        private IShopSearchRepository repository;

        public ShopSearchController(IShopSearchRepository shopSearchRepository)
        {
            this.repository = shopSearchRepository;
        }


        // GET: api/ShopSearch
        public IEnumerable<ShopSearch> Get()
        {

            IEnumerable<ShopSearch> res = repository.Shops("");

            if (res == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No shops!", "")),
                    ReasonPhrase = "GRRR Product ID Not Found"
                };

                throw new HttpResponseException(resp);
            }

            return res;
        }


        // GET: api/ShopSearch
        public IEnumerable<ShopSearch> Get(string location)
        {

            IEnumerable<ShopSearch> res = repository.Shops(location);

            if (res == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No shops!", location)),
                    ReasonPhrase = "GRRR Product ID Not Found"
                };
                
                throw new HttpResponseException(resp);
            }

            return res.OrderBy(x=>x.Distance);

        }

        // GET: api/ShopSearch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShopSearch
        public void Post(ShopSearch value)
        {

        }

        // PUT: api/ShopSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShopSearch/5
        public void Delete(int id)
        {
        }
    }
}
