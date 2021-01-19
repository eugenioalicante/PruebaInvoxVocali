using System.Collections.Generic;
using PruebaInvoxMedicalService.Service.Dto;

namespace PruebaInvoxMedicalService.Service.Interface
{
    public interface IPeriodService
    {
        /// <summary>
        /// Sum of periods
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        byte[] GetPeriodCSV(List<DtoPeriodRequest> request);
    }
}