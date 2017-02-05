$(function() {
    Tinymce.initAdvence({});
    var coverPhotoBase64;
    $('#title')
        .change(function () {
            $('#slug').val(globals.slugify($(this).val()));
        });

    $('#slug')
        .change(function() {
            $(this).val(globals.slugify($(this).val()));
        });

    $('#cover-photo')
        .change(function () {
            AjaxLoader.ShowLoader();
            globals.readFileAsBase64(this).then(function (base64) {
                new Promise(function(resolve, reject) {
                    coverPhotoBase64 = base64;

                    resolve();
                }).then(function() {
                    AjaxLoader.HideLoader();
                });
            });
        });

    $('.create-post')
        .click(function () {
            var url = $(this).attr('href');
            var title = $('#title').val();
            var slug = $('#slug').val();
            var categoryID = $('#category').val();
            var languageID = $('#language').val();
            var statusID = $('#status').val();
            var description = $('#description').val();

            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    Title: title,
                    Slug: slug,
                    CategoryID: categoryID,
                    LanguageID: languageID,
                    StatusID: statusID,
                    Description: description,
                    CoverPhotoBase64: coverPhotoBase64
                },
                beforeSend: function() {
                    AjaxLoader.ShowLoader();
                },
                dataType: 'json',
                success: function (response) {
                    AjaxLoader.HideLoader();
                    console.log(response);
                    if (response.IsSuccess) {
                        
                    } else {
                        
                    }
                }
            });
            return false;
        });

});

