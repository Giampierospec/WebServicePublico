using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSPublicApi.Models;
using WSPublicApi.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class CrediticioController : Controller
    {
        private WSBDContext _db;
        private HistorySave _history;
        private Regex VerificarCedula = new Regex("^(d{11})$");

        public CrediticioController(WSBDContext context)
        {
            _db = context;
            _history = new HistorySave();
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(string cedula)
        {
           var  result = default(IActionResult);
            _history.SaveHistory(HttpContext);
            var Persona = _db.Persona.FirstOrDefault(x => x.Cedula.Trim() == cedula.Trim())?.Id;
            var saludFinanciera = default(dynamic);
            if (Persona != null)
            {
                saludFinanciera = _db.HistorialCrediticio.Include(x => x.Persona1)
                .Where(x => x.IdPersona == Persona)
                .GroupBy(x => x.IdPersona)
                .Select(x => x.FirstOrDefault())
                .Select(x => new
                {
                    Comentario = x.Concepto,
                    x.MontoTotal
                })
                .ToList();
                result = Ok(saludFinanciera);
            }
            else
                result = NotFound("No se pudo encontrar al cliente");
           
          return result;
        }

        // GET api/<controller>/5
        [HttpGet("Historial")]
        public IActionResult GetHistorial(string cedula)
        {
            var result = default(IActionResult);
            _history.SaveHistory(HttpContext);
            var Persona = _db.Persona.FirstOrDefault(x => x.Cedula.Trim() == cedula.Trim())?.Id;
            var saludFinanciera = default(dynamic);
            if (Persona != null)
            {
                saludFinanciera = _db.HistorialCrediticio.Include(x => x.Persona1)
                .Where(x => x.IdPersona == Persona)
                .GroupBy(x => x.IdPersona)
                .Select(x => x.FirstOrDefault())
                .Select(x => new
                {
                     x.Concepto,
                    RncEmpresa = x.Persona1.Cedula,
                     Fecha = x.Fecha.HasValue ? x.Fecha.Value.ToString("dd-MM-yyyy"): string.Empty,
                    x.MontoTotal
                })
                .ToList();
                result = Ok(saludFinanciera);
            }
            else
                result = NotFound("No se pudo encontrar al cliente");
            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
