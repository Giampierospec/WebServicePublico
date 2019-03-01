using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(11,ErrorMessage = "El limite es 11")]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<HistorialCrediticio> Personas { get; set; };

    }
}
