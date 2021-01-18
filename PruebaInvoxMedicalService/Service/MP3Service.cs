using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PruebaInvoxMedical.Infrastructure.Exceptions;
using PruebaInvoxMedicalService.Service.AppSettings;
using PruebaInvoxMedicalService.Service.Dto;
using PruebaInvoxMedicalService.Service.Enum;
using PruebaInvoxMedicalService.Service.Interface;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PruebaInvoxMedicalService.Service.Service
{
    public class MP3Service : IMP3Service
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly FileExtensions _fileExtensions;

        public MP3Service(IHostingEnvironment hostingEnvironment,
                          IOptions<FileExtensions> fileExtensions)
        {
            _hostingEnvironment = hostingEnvironment;
            _fileExtensions = fileExtensions.Value;
        }

        /// <summary>
        /// Convert an MP3 file into an text
        /// </summary>
        /// <param name="enumMP3"></param>
        /// <returns></returns>
        public string GetText(DtoUploadManagerData uploadManagerData)
        {
            string extension = Path.GetExtension(uploadManagerData.File.FileName);

            if (!_fileExtensions.AllowedFileExtensions.Any(x => x.Equals(extension)))
            {
                throw new ServerErrorFivePercent("Formato de documento no soportado");
            }

            CauseError();

            var pathText = Path.Combine(_hostingEnvironment.ContentRootPath, "Texts");

            string text = "";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Random random = new Random();
            int randomNumber = random.Next(1, 4);

            switch ((MP3.EnumMP3)randomNumber)
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
