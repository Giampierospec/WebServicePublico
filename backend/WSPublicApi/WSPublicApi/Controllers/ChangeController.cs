using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSPublicApi.Models;
using WSPublicApi.Utils;

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class ChangeController : Controller
    {
        WSBDContext _db;
        private HistorySave _saveHistory;

        public ChangeController(WSBDContext context)
        {
            _db = context;
            _saveHistory = new HistorySave(_db);
        }
        /// <summary>
        /// Trae el cambio de moneda en base a un codigo
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string cod)
        {
            var result = default(IActionResult);
            try
            {
                _saveHistory.SaveHistory(HttpContext);
                var moneda = _db.MonedasTasa.FirstOrDefault(x => x.Codigo.ToUpper().Trim() == cod.ToUpper().Trim());
                if (moneda != null)
                    result = Ok(new { moneda?.Codigo, moneda?.TasaCambio });
                else
                    result = NotFound($"No se encontro el código {cod}");
                
            }
            catch(Exception ex)
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


    }
}
