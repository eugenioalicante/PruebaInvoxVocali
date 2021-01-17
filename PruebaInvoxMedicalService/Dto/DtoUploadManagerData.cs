using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaInvoxMedicalService.Service.Dto
{
    public class DtoUploadManagerData
    {
        public IFormFile File { get; set; }
    }
}
