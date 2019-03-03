using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSPublicApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private WSBDContext _db;

        public LogController(WSBDContext context)
        {
            _db = context;
        }
        /// <summary>
        /// Log de llamadas al web service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.LogWS.ToList());
        }

        // GET api/<controller>/5
    }
}
