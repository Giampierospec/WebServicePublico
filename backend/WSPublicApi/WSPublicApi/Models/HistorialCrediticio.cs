using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class HistorialCrediticio
    {
        [Key]
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdEmpresa { get; set; }
        public string Concepto { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }
        [ForeignKey("IdEmpresa")]
        public Persona Persona1 { get; set; }
    }
}
