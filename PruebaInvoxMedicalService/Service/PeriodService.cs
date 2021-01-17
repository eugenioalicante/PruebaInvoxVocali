using CsvHelper;
using PruebaInvoxMedicalService.Service.Dto;
using PruebaInvoxMedicalService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PruebaInvoxMedicalService.Service.Service
{
    public class PeriodService : IPeriodService
    {
        /// <summary>
        /// Sum of periods
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public byte[] GetPeriod(List<DtoPeriodRequest> request)
        {
            List<TimeSpan> list = new List<TimeSpan>();

            foreach (var item in request)
            {
                list.Add(item.Start);
                list.Add(item.End);
            }

            // Ascending sorted list
            list = list.OrderBy(o => o).ToList();

            List<DtoPeriodResponse> listReturn = new List<DtoPeriodResponse>();

            TimeSpan[] array = list.ToArray();

            TimeSpan sInit = TimeSpan.MinValue;
            TimeSpan sFin = TimeSpan.MinValue;

            // Sum of Periods
            for (int i = 0; i < (array.Length - 1); i++)
            {
                sInit = array[i];
                sFin = array[i + 1];

                if ((array.Length - 1) != (i + 1))
                {
                    sFin = sFin.Subtract(new TimeSpan(0, 1, 0));
                }

                listReturn.Add(new DtoPeriodResponse { Id = i + 1, Start = sInit, End = sFin });
            }

            return GenerateCSV(listReturn);
        }

        /// <summary>
        /// Generate CSV
        /// </summary>
        /// <param name="dtoPeriodResponse"></param>
        /// <returns></returns>
        private byte[] GenerateCSV(List<DtoPeriodResponse> dtoPeriodResponse)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            byte[] result = null;
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, System.Text.Encoding.GetEncoding(1252)))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentUICulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.WriteRecords(dtoPeriodResponse);
                writer.Flush();

                result = memoryStream.ToArray();

                return result;
            }
        }
    }
}
