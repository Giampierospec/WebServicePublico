using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSPublicApi.Models;

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class ChangeController : Controller
    {
        WSBDContext _db;
        public ChangeController(WSBDContext context)
        {
            _db = context;
        }
        // GET api/values
        //[HttpGet]
        //public IEnumerable<Persona> Get()
        //{
        //    return _db.Persona.ToList();
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
