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
        private Regex validateYear = new Regex("^(19[6-9][0-9]|20[0-9][0-9])$");
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
            _saveHistory.SaveHistory(HttpContext);
            if (validateYear.IsMatch(year))
                result = Ok(_db.Inflaciones.FirstOrDefault(x => x.Periodo.ToString() == year));
            else
                result = BadRequest($"El valor {year} no es valido");
            return result;
        }

       
    }
}
