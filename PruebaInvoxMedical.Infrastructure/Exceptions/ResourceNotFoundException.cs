using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PruebaInvoxMedical.Infrastructure.Exceptions
{
    public class ServerErrorFivePercent : BaseException
    {
        public ServerErrorFivePercent(string mensaje = "Error en el servidor 5%.") : base(mensaje)
        {
            this.StatusCode = (HttpStatusCode)501;
        }
    }
}
