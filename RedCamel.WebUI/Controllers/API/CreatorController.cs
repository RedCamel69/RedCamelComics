using RedCamel.Domain.Abstract;
using RedCamel.Domain.Concrete;
using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RedCamel.WebUI.Controllers.API
{
    public class CreatorController : ApiController
    {
        // GET: api/Creator
        [ResponseType(typeof(IEnumerable<Creator>))]
        public IHttpActionResult Get()
        {
            ICreatorRepository repo = new CreatorRepository();
            return  this.Ok(repo.Creators);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Creator/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Creator
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Creator/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Creator/5
        public void Delete(int id)
        {
        }
    }
}
