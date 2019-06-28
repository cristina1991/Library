$(document).on('click', '.addAuthorImages', function () {
    var authorId = $(this).attr('id').replace("addAuthorImage_", "");
    $('#inputAuthorPhotoUpload').attr('data-authorId',authorId);
    $('#inputAuthorPhotoUpload').click();
});

$(document).on('change', "#inputAuthorPhotoUpload", function () {
    var authorId = $(this).attr('data-authorId');
    var files = $("#inputAuthorPhotoUpload")[0].files;
    var authorData = new FormData();
    for (var i = 0; i < files.length; i++) {
        authorData.append('files[' + i + ']', files[i]);
    }
    authorData.append('authorId', authorId)

    $.ajax({
        type: "POST",
        url: getBaseUrl() + "UploadAuthorPhoto",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: authorData,
        success: function (res) {
            if (res.success == true) {
                location.reload();
            }
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', ".deletesAuthor", function () {
    var authorId = $(this).attr("id").replace("deleteAuthor_", "");

    $('#deleteAuthorModal').modal('show');

    $(document).on('click', '#deleteAuthorBtn', function () {
        $.ajax({
            url: getBaseUrl() + 'Delete',
            type: "POST",
            data: { authorId: authorId },
            success: function (result) {
                $('#deleteAuthorModal').modal('hide');
                location.reload();
            },
            error: function (ex) {
                alert(ex);
            }
        });
    });
});