﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSPublicApi.Models;
using WSPublicApi.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSPublicApi.Controllers
{
    [Route("api/[controller]")]
    public class HistorialCrediticioController : Controller
    {
        private WSBDContext _db;
        private HistorySave _history;

        public HistorialCrediticioController(WSBDContext context)
        {
            _db = context;
            _history = new HistorySave(context);
        }
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
                    .Where(x => x.IdPersona == Persona)
                    .GroupBy(x => x.IdPersona)
                    .Select(x => x.FirstOrDefault())
                    .Select(x => new
                    {
                        x.Concepto,
                        RncEmpresa = x.Persona1.Cedula,
                        Fecha = x.Fecha.HasValue ? x.Fecha.Value.ToString("dd-MM-yyyy") : string.Empty,
                        x.MontoTotal
                    })
                    .ToList();
                    result = Ok(saludFinanciera);
                }
                else
                    result = NotFound("No se pudo encontrar al cliente");
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
                result = BadRequest("Ocurrio un error");

            }


            return result;
        }
    }
}
