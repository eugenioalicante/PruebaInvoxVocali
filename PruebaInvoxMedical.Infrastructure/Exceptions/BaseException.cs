﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PruebaInvoxMedical.Infrastructure.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }


        private BaseException() : base()
        {
        }

        protected BaseException(string mensaje) : base(mensaje)
        {
        }
    }
}
