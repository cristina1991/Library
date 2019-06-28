$(document).ready(function () {
    SelectizeDropdowns();
});

function SelectizeDropdowns() {
    $('#select-author').selectize({
        create: function (input, callback) {
            $.ajax({
                url: getBaseUrl() + 'AddAuthor',
                type: 'POST',
                data: { authorName: input },
                success: function (res) {
                    callback({ value: res.authorId, text: input });
                }
                ,
                error: function (ex) {
                    alert(ex);
                }
            });
        },
        sortField: 'text'
    });


    $('#select-genre').selectize({
        create: function (input, callback) {
            $.ajax({
                url: getBaseUrl() + 'AddGenre',
                type: 'POST',
                data: { genreName: input },
                success: function (res) {
                    callback({ value: res.genreId, text: input });
                }
                ,
                error: function (ex) {
                    alert(ex);
                }
            });
        },
        sortField: 'text'
    });
}

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
    $.ajax({
        type: "POST",
        url: getBaseUrl() + "AddFavourite",
        data: { bookId: bookId },
        success: function (res) {
            location.reload();
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', ".deletesBook", function () {
    var bookId = $(this).attr("id").replace("deleteBook_", "");

    $('#deleteBookModal').modal('show');

    $(document).on('click', '#deleteBookBtn', function () {
        $.ajax({
            url: getBaseUrl() + 'Delete',
            type: "POST",
            data: { bookId: bookId },
            success: function (result) {
                $('#deleteBookModal').modal('hide');
            },
            error: function (ex) {
                alert(ex);
            }
        });
    });
});
