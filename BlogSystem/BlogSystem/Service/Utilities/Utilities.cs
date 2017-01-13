using System.Drawing;
using System.IO;

namespace Service.Utilities
{
    public class Utilities
    {
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            return File.Exists(imagePath) ? File.ReadAllBytes(imagePath) : null;
        }

        public static Image ConvertByteArrayToImage(byte[] imageBytes)
        {
            if (imageBytes == null)
            {
                return null;
            }
            else
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }
    }
}
