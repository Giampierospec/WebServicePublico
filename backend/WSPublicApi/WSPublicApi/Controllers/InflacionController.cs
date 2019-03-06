using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSPublicApi.Models;
using WSPublicApi.Utils;

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class InflacionController : Controller
    {
        private WSBDContext _db;
        private HistorySave _saveHistory;
        private Regex validateYear = new Regex("^(198[0-9]|20[0-1][0-8])$");
        public InflacionController(WSBDContext context)
        {
            _db = context;
            _saveHistory = new HistorySave(_db);
        }
        /// <summary>
        /// Conseguir el indice de inflacion
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string year)
        {
            var result = default(IActionResult);
            try
            {
                _saveHistory.SaveHistory(HttpContext);
                var inflacion = _db.Inflaciones.FirstOrDefault(x => x.Periodo.ToString() == year);
                if (validateYear.IsMatch(year))
                    result = Ok(new { inflacion?.Indice, inflacion?.Periodo });
                else
                    result = BadRequest($"El valor {year} no es valido o no esta en el rango 1980-2018");   
            }
            catch (Exception ex)
            {

                _db.ExceptionsApi.Add(new ExceptionApi()
                {
                    Msg = ex.Message,
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
