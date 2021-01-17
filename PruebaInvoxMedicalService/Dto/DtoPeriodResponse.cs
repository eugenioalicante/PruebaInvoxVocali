using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaInvoxMedicalService.Service.Dto
{
    public class DtoPeriodResponse
    {
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
