using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class LogWs
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime FechaInvocacion { get; set; }
        public string NombreWS { get; set; }
        public string Method { get; set; }
    }
}
