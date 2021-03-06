﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaInvoxMedicalService.Service.Dto;
using PruebaInvoxMedicalService.Service.Enum;
using PruebaInvoxMedicalService.Service.Interface;

namespace PruebaInvoxMedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MP3Controller : ControllerBase
    {
        private readonly IMP3Service _mP3Service ;

        public MP3Controller(IMP3Service mP3Service)
        {
            _mP3Service = mP3Service;
        }

        /// <summary>
        /// MP3 to text
        /// </summary>
        /// <param name="enumAttributes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostMP3([FromForm]DtoUploadManagerData dtoUploadManagerData)
        {
            return Ok(_mP3Service.GetText(dtoUploadManagerData));
        }
    }
}