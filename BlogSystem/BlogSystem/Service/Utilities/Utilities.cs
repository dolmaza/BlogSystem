using System.IO;

namespace Service.Utilities
{
    public class Utilities
    {
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            return File.Exists(imagePath) ? File.ReadAllBytes(imagePath) : null;
        }

    }
}
