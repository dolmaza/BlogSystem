using Service.Utilities;
using System;
using System.IO;

namespace BlogSystem.Admin.Reusable.Helpers
{
    public class UserHelper
    {
        public static string GetAvatarUniqueName()
        {
            return $"Avatar_{Guid.NewGuid().ToString().Substring(0, 8)}.jpeg";
        }

        public static void SaveAvatar(byte[] avatarBytes, string avatarName, string oldAvatarName = null)
        {
            DeleteAvatar(oldAvatarName);

            if (avatarBytes != null && !string.IsNullOrWhiteSpace(avatarName))
            {
                var image = Utilities.ConvertByteArrayToImage(avatarBytes);

                image.Save($"{AppSettings.UploadFolderPhysicalPath}{avatarName}");
            }
        }

        public static void DeleteAvatar(string avatarName)
        {
            if (!string.IsNullOrWhiteSpace(avatarName))
            {
                var oldAvatarPath = $"{AppSettings.UploadFolderPhysicalPath}{avatarName}";
                if (File.Exists(oldAvatarPath))
                {
                    File.Delete(oldAvatarPath);
                }
            }
        }
    }
}