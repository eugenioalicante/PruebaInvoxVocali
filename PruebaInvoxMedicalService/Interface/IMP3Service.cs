using PruebaInvoxMedicalService.Service.Enum;

namespace PruebaInvoxMedicalService.Service.Interface
{
    public interface IMP3Service
    {
        /// <summary>
        /// Convert an MP3 file into an audio
        /// </summary>
        /// <param name="enumMP3"></param>
        /// <returns></returns>
        string GetText(MP3.EnumMP3 enumMP3);
    }
}