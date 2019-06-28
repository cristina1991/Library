$(document).on('click', ".deletesGenre", function () {
    var genreId = $(this).attr("id").replace("deleteGenre_", "");

    $('#deleteGenreModal').modal('show');

    $(document).on('click', '#deleteGenreBtn', function () {
        $.ajax({
            url: getBaseUrl() + 'Delete',
            type: "POST",
            data: { genreId: genreId },
            success: function (result) {
                $('#deleteGenreModal').modal('hide');
                location.reload();
            },
            error: function (ex) {
                alert(ex);
            }
        });
    });
});