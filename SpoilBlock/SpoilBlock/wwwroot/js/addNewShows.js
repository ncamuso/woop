$(document).ready(function () {
    $(document).on("click", ".btn-primary", function () {
        $.ajax({
            url: '/Add/AddMediaToWatchlist',
            data: {
                media: `{Imdbid: "${$(event.target).attr("id")}", image: "${$(event.target).parent().parent().find("img").attr('src')}", title: "${$(event.target).parent().parent().find(".mediatitle").attr('value')}", description: "${$(event.target).parent().parent().find(".mediadescription").attr('value')}"}`
            },
            method: 'POST',
            success: DisableButtonsForShowsAlreadyOnWatchlist
        });
    });
});

$.ajax({
    url: '/Add/GetCurrentWatchListIDs',
    success: DisableButtonsForShowsAlreadyOnWatchlist
});

function DisableButtonsForShowsAlreadyOnWatchlist(data) {
    var results = JSON.parse(data.list);
    $.each(results, function (i) {
        $('.btn').each(function () {
            if ($(this).attr('id') == results[i]) {
                $(this).prop("disabled", true);
                $(this).prop("class", "btn btn-secondary");
                $(this).prop("value", "Added");
            }
        });
    });
}
