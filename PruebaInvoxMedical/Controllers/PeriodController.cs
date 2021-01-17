using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PruebaInvoxMedicalService.Service.Dto;
using PruebaInvoxMedicalService.Service.Interface;

namespace PruebaInvoxMedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _periodService;

        public PeriodController(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        /// <summary>
        /// Sum of periods in CSV
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get([FromBody]List<DtoPeriodRequest> request)
        {
            byte[] csv =  _periodService.GetPeriod(request);

            return File(csv, "application/csv", "Period_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".csv");
        }
    }
}
