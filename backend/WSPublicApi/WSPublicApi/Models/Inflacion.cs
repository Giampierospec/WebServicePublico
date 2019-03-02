﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSPublicApi.Models
{
    public class Inflacion
    {
        [Key]
        public int Id { get; set; }
        public int Periodo { get; set; }
        public decimal Indice { get; set; }
    }
}
