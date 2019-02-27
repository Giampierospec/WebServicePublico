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
    }
}
