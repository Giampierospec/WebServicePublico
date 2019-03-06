using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class ExceptionApi
    {
        [Key]
        public int Id { get; set; }
        public string StackTrace { get; set; }
        public string Msg { get; set; }
        public string Method { get; set; }
    }
}
