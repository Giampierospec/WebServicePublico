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
            var result = default(IActionResult);
            try
            {
                result = Ok(_db.LogWS.Select(x => new { x.NombreWS, x.Ip, x.Method, x.FechaInvocacion }).ToList());
            }
            catch (Exception ex)
            {

                _db.ExceptionsApi.Add(new ExceptionApi()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Method = Request.Path
                });
                _db.SaveChanges();
                result = BadRequest("Ocurrió un Error");
            }
            return result;
        }

        // GET api/<controller>/5
    }
}
