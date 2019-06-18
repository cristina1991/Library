//Delete selected book
$(document).on('click', ".deletesBook", function () {
    var bookId = $(this).attr("id").replace("deleteBook_", "");

    $('#deleteBookModal').modal('show');

    $(document).on('click', '#deleteBookBtn', function () {
        $.ajax({
            url: getBaseUrl() + 'Books/Delete',
            type: "POST",
            data: { bookId: bookId },
            success: function (result) {
                $('#deleteBookModal').modal('hide');
                location.reload();
            },
            error: function (ex) {
                alert(ex);
            }
        });
    });
});

//Open selected book
//$(document).on('click', '.booksContainer', function () {
//    var bookId = $(this).attr('id').replace("bookContainer_", "");

//    $.ajax({
//        url: getBaseUrl() + 'Books/SingleBook',
//        type: "POST",
//        data: { bookId: bookId },
//        success: function (result) {
            
//        },
//        error: function (ex) {
//            alert(ex);
//        }
//    });
//})




function getBaseUrl() {
    var re = new RegExp(/^.*\//);
    return re.exec(window.location.href);
}