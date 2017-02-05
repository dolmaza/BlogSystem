using Service.IServices;
using Service.Properties;
using Service.Services;
using System.Collections.Generic;

namespace Service.Validation
{
    public class CustomError
    {
        #region Properties
        public int Code { get; set; }
        public int SubCode { get; set; }
        public string ErrorMessage { get; set; }
        #endregion Properties
    }

    public class CustomErrors
    {
        public static CustomError Abort { get; set; } = new CustomError { Code = 0, ErrorMessage = Resources.Abort };
        public static CustomError TitleRequired { get; set; } = new CustomError { Code = 1, ErrorMessage = Resources.ValidationFieldIsRequired };
        public static CustomError SlugRequired { get; set; } = new CustomError { Code = 1, SubCode = 1, ErrorMessage = Resources.ValidationFieldIsRequired };
        public static CustomError SlugMustBeUnique { get; set; } = new CustomError { Code = 1, SubCode = 2, ErrorMessage = Resources.ValidationSlugUnique };
        public static CustomError CoverPhotoRequired { get; set; } = new CustomError { Code = 2, ErrorMessage = Resources.ValidationFieldIsRequired };
        public static CustomError CategoryRequired { get; set; } = new CustomError { Code = 3, ErrorMessage = Resources.ValidationFieldIsRequired };
        public static CustomError DescriptionRequired { get; set; } = new CustomError { Code = 4, ErrorMessage = Resources.ValidationFieldIsRequired };

    }

    public class ValidationBase
    {

        #region Methods

        public static CustomError ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return CustomErrors.TitleRequired;
            }

            return null;
        }

        public static CustomError ValidationSlug(string slug, int? postID = null)
        {
            IPostService postService = new PostService();

            if (string.IsNullOrWhiteSpace(slug))
            {
                return CustomErrors.SlugRequired;
            }
            else if (postService.IsSlugUnique(slug, postID))
            {
                return CustomErrors.SlugMustBeUnique;
            }

            return null;
        }

        public static CustomError ValidateCoverPhotoBase64(string coverPhotoNameBase64)
        {
            if (string.IsNullOrWhiteSpace(coverPhotoNameBase64))
            {
                return CustomErrors.CoverPhotoRequired;
            }

            return null;
        }

        public static CustomError ValidateCategory(int? categoryID)
        {
            if (categoryID == null)
            {
                return CustomErrors.CategoryRequired;
            }

            return null;
        }

        public static CustomError ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return CustomErrors.DescriptionRequired;
            }

            return null;
        }

        #endregion Methods
    }

    public class Validation : ValidationBase
    {
        public static List<CustomError> ValidatePostCreateForm(string title, string slug, string coverPhotoBase64, int? categoryID, string description, int? postID = null)
        {
            var errors = new List<CustomError>
            {
                ValidateTitle(title),
                ValidationSlug(slug,postID),
                ValidateCoverPhotoBase64(coverPhotoBase64),
                ValidateCategory(categoryID),
                ValidateDescription(description)
            };

            errors.RemoveAll(e => e == null);

            return errors;

        }
    }
}
