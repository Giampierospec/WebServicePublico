using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSPublicApi.Models;

namespace WSPublicApi.Utils
{
    public class HistorySave
    {
        private WSBDContext _db;

        public HistorySave()
        {
        }

        public HistorySave(WSBDContext bd)
        {
            _db = bd;
        }
        /// <summary>
        /// Guardar la historia
        /// </summary>
        /// <param name="context"></param>
        public void SaveHistory(HttpContext context)
        {
            _db.LogWS.Add(new LogWs()
            {
                FechaInvocacion = DateTime.Now,
                Ip = context.Connection.RemoteIpAddress.ToString(),
                Method = context.Request.Method,
                NombreWS = context.Request.Path
            });
            _db.SaveChanges();
        }

    }
}
