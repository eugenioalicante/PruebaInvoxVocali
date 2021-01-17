using Microsoft.AspNetCore.Hosting;
using PruebaInvoxMedical.Infrastructure.Exceptions;
using PruebaInvoxMedicalService.Service.Enum;
using PruebaInvoxMedicalService.Service.Interface;
using System;
using System.IO;
using System.Text;

namespace PruebaInvoxMedicalService.Service.Service
{
    public class MP3Service : IMP3Service
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public MP3Service(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;            
        }

        /// <summary>
        /// Convert an MP3 file into an audio
        /// </summary>
        /// <param name="enumMP3"></param>
        /// <returns></returns>
        public string GetText(MP3.EnumMP3 enumMP3)
        {
            CauseError();

            var pathText = Path.Combine(_hostingEnvironment.ContentRootPath, "Texts");

            string text = "";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            switch (enumMP3)
            {
                case MP3.EnumMP3.MP3_1:
                    text = File.ReadAllText(Path.Combine(pathText, "Texto1.txt"), Encoding.GetEncoding(1252));
                    break;
                case MP3.EnumMP3.MP3_2:
                    text = File.ReadAllText(Path.Combine(pathText, "Texto2.txt"), Encoding.GetEncoding(1252));
                    break;
                case MP3.EnumMP3.MP3_3:
                    text = File.ReadAllText(Path.Combine(pathText, "Texto3.txt"), Encoding.GetEncoding(1252));
                    break;
                case MP3.EnumMP3.MP3_4:
                    text = File.ReadAllText(Path.Combine(pathText, "Texto4.txt"), Encoding.GetEncoding(1252));
                    break;
            }

            return text;
        }


        /// <summary>
        /// Causes a random error
        /// </summary>
        private void CauseError()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            if (randomNumber <= 5)
            {
                throw new ServerErrorFivePercent("Error aleatorio 5%");
            }
        }
    }
}
