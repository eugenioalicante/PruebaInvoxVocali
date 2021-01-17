using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaInvoxMedical.Infrastructure.Exceptions
{
    public class ErrorProblemDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public string[] resultError { get; set; }
    }
}
