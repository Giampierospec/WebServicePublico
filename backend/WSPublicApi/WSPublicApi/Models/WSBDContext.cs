using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class WSBDContext:DbContext
    {

        public WSBDContext(DbContextOptions<WSBDContext> options)
            :base(options)
        {

        }
        public DbSet<CambioMoneda> MonedasTasa { get; set; }
        public DbSet<LogWs> LogWS { get; set; }
        public DbSet<Inflacion> Inflaciones { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<HistorialCrediticio> HistorialCrediticio { get; set; }
        public DbSet<ExceptionApi> ExceptionsApi{ get; set; }
    }
}
