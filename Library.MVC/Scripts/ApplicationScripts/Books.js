$(document).on('click', '.addBookImages', function () {
    var bookId = $(this).attr('id').replace("addBookImage_", "");
    $('#inputBookPhotoUpload').attr('data-bookId', bookId);
    $('#inputBookPhotoUpload').click();
});

$(document).on('change', "#inputBookPhotoUpload", function () {
    var bookId = $(this).attr('data-bookId');
    var files = $("#inputBookPhotoUpload")[0].files;
    var bookData = new FormData();
    for (var i = 0; i < files.length; i++) {
        bookData.append('files[' + i + ']', files[i]);
    }
    bookData.append('bookId', bookId)

    $.ajax({
        type: "POST",
        url: getBaseUrl() + "UploadBookPhoto",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: bookData,
        success: function (res) {
            if (res.success == true) {
                alert("Photo succesfully uploaded");
                location.reload();
            }
        },
        error: function (error) {
            alert(error);
        }
    });
});