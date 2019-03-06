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
            _history = new HistorySave(context);
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(string cedula)
        {
            var result = default(IActionResult);
            try
            {
                _history.SaveHistory(HttpContext);
                var Persona = _db.Persona.FirstOrDefault(x => x.Cedula.Trim() == cedula.Trim())?.Id;
                var saludFinanciera = default(dynamic);
                if (Persona != null)
                {
                    saludFinanciera = _db.HistorialCrediticio.Include(x => x.Persona1)
                                    .FirstOrDefault(x => x.IdPersona == Persona);
                    result = Ok(new { Comentario = saludFinanciera?.Concepto, saludFinanciera?.MontoTotal});
                }
                else
                    result = NotFound("No se pudo encontrar al cliente");
            }
            catch (Exception ex)
            {
                _db.ExceptionsApi.Add(new ExceptionApi()
                {
                    Msg= ex.Message,
                    StackTrace = ex.StackTrace,
                    Method = Request.Path
                });
                _db.SaveChanges();
                result = BadRequest("Ocurrio un error");
            }
           
            

            return result;
        }

        // GET api/<controller>/5
       

    }
}
