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

$(document).on('click', '.plus-review', function () {
    $('.new-review-content').toggle('slow');
});

$(document).on('click', '.sendReviewBtns', function () {
    var bookId = $(this).attr('id').replace("sendReviewBtn_", "");
    var bookReview = $('#bookReviewText').val();

    if (bookReview == "") {
        return;
    }
    $.ajax({
        type: "POST",
        url: getBaseUrl() + "AddReview",
        data: { bookReview: bookReview, bookId:bookId},
        success: function (res) {
            location.reload();
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', '.favourite-book-icon', function () {
    var bookId = $(this).attr('id').replace("favouriteBook_", "");

});