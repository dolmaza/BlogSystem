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
        public static CustomError TitleRequired { get; set; } = new CustomError { Code = 1, ErrorMessage = "" };
        public static CustomError SlugRequired { get; set; } = new CustomError { Code = 1, SubCode = 1, ErrorMessage = "" };
        public static CustomError SlugMustBeUnique { get; set; } = new CustomError { Code = 1, SubCode = 2, ErrorMessage = "" };
        public static CustomError CoverPhotoRequired { get; set; } = new CustomError { Code = 2, ErrorMessage = "" };
        public static CustomError CategoryRequired { get; set; } = new CustomError { Code = 3, SubCode = 1, ErrorMessage = "" };
        public static CustomError DescriptionRequired { get; set; } = new CustomError { Code = 4, SubCode = 1, ErrorMessage = "" };

    }

    public class ValidationBase
    {
        private static IPostService _postService;

        public ValidationBase()
        {
            _postService = new PostService();
        }

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
            if (string.IsNullOrWhiteSpace(slug))
            {
                return CustomErrors.SlugRequired;
            }
            else if (_postService.IsSlugUnique(slug, postID))
            {
                return CustomErrors.SlugMustBeUnique;
            }

            return null;
        }

        public static CustomError ValidateCoverPhoto(string coverPhotoName)
        {
            if (string.IsNullOrWhiteSpace(coverPhotoName))
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
        public static List<CustomError> ValidatePostCreateForm(string title, string slug, string coverPhoto, int? categoryID, string description, int? postID = null)
        {
            var errors = new List<CustomError>
            {
                ValidateTitle(title),
                ValidationSlug(slug,postID),
                ValidateCoverPhoto(coverPhoto),
                ValidateCategory(categoryID),
                ValidateDescription(description)
            };

            errors.RemoveAll(e => e == null);

            return errors;

        }
    }
}
