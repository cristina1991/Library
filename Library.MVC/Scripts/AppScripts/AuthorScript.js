//Delete selected author
$(document).on('click', ".deletesAuthor", function () {
    var authorId = $(this).attr("id").replace("deleteAuthor_", "");

    $('#deleteAuthorModal').modal('show');

    $(document).on('click', '#deleteAuthorBtn', function () {
        $.ajax({
            url: getBaseUrl() + 'Authors/Delete',
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

function getBaseUrl() {
    var re = new RegExp(/^.*\//);
    return re.exec(window.location.href);
}