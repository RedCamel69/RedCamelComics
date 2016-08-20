using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;

namespace RedCamel.WebUI.Controllers.API
{
    public class ConventionController : ApiController
    {
        private IConventionRepository repository;

        public ConventionController(IConventionRepository shopSearchRepository)
        {
            this.repository = shopSearchRepository;
        }
        // GET: api/Convention
        public IEnumerable<Convention> Get(string country)
        {
            if (country == "undefined")
            { return repository.Conventions(); }
            else
            {
                return repository.Conventions(country);
            }
        }

        // GET: api/Convention/5
        public string Get()
        {
            return "value";
        }

        // POST: api/Convention
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Convention/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Convention/5
        public void Delete(int id)
        {
        }
    }
}
