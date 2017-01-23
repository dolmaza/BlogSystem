$(function() {
    Tinymce.initAdvence({});

    $('#title')
        .change(function () {
            $('#slug').val(slugify($(this).val()));
        });

    $('#slug')
        .change(function() {
            $(this).val(slugify($(this).val()));
        });

});

function slugify(text) {
    return text.toString().toLowerCase()
      .replace(/\s+/g, '-')           // Replace spaces with -
      .replace(/[^\w\-]+/g, '')       // Remove all non-word chars
      .replace(/\-\-+/g, '-')         // Replace multiple - with single -
      .replace(/^-+/, '')             // Trim - from start of text
      .replace(/-+$/, '');            // Trim - from end of text
}