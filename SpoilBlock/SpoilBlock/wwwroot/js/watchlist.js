document.addEventListener('DOMContentLoaded', function () {
    const table = document.getElementById('sortTable');
    const headers = table.querySelectorAll('th');
    const tableBody = table.querySelector('tbody');
    const rows = tableBody.querySelectorAll('tr');


    const directions = Array.from(headers).map(function (header) {
        return '';
    });


    const transform = function (index, content) {

        const type = headers[index].getAttribute('data-type');
        switch (type) {
            case 'number':
                return parseFloat(content);
            case 'string':
            default:
                return content;
        }
    };

    const sortList = function (index) {

        const direction = directions[index] || 'asc';


        const multiplier = direction === 'asc' ? 1 : -1;

        const newRows = Array.from(rows);

        newRows.sort(function (rowA, rowB) {
            const cellA = rowA.querySelectorAll('td')[index].innerHTML;
            const cellB = rowB.querySelectorAll('td')[index].innerHTML;

            const a = transform(index, cellA);
            const b = transform(index, cellB);

            switch (true) {
                case a > b:
                    return 1 * multiplier;
                case a < b:
                    return -1 * multiplier;
                case a === b:
                    return 0;
            }
        });


        [].forEach.call(rows, function (row) {
            tableBody.removeChild(row);
        });


        directions[index] = direction === 'asc' ? 'desc' : 'asc';


        newRows.forEach(function (newRow) {
            tableBody.appendChild(newRow);
        });
    };

    [].forEach.call(headers, function (header, index) {
        header.addEventListener('click', function () {
            sortList(index);
        });
    });
});

$(document).ready(function () {
    $(document).on("click", "button[name$='deleteButton']", function () {
        $(event.target).parents('tr').remove();
        $.ajax({
            url: '/Add/DeleteShowFromWatchlist',
            data: { id: `${$(event.target).attr("data-showid")}` },
            method: "POST",
            success: removeShowFromDisplay,
            headers: {'validate-ajax': "true"}
        });
    });
});


$(document).ready(function () {
    refreshWatchlistStatus();

    $(document).on("click", "a[name$='ddItem']", function ($e) {
        $e.preventDefault();
        $.ajax({
            url: '/Add/UpdateMediaStatus',
            data: {
                MediaId: `${$(event.target).data("mediaid")}`,
                BlockageLevel: `${$(event.target).data("status")}`
            },
            method: "POST",
            success: refreshWatchlistStatus,
            headers: { 'validate-ajax': "true" }
        });
    });
});


function refreshWatchlistStatus() {
    $.ajax({
        url: '/Add/GetMediaStatuses',
        success: refreshButtonNames
    });
}

function refreshButtonNames(data) {
    var results = JSON.parse(data.list);
    $("button[name$='ddButton']").each(function (i) {

        $(this).attr("data-status", results.find(e => e.MediaId == $(this).attr("data-mediaid")).BlockageLevel);

        if ($(this).attr("data-status") == 0)
            $(this).html("Haven't Started");
        else if ($(this).attr("data-status") == 1)
            $(this).html("Currently Watching");
        else
            $(this).html("Completed");
    });
}

function removeShowFromDisplay(data) {
    //window.location.replace('/Watchlist');

    location.reload();
    //if ($('#sortTable tr').length == 1) {  //this code works but breaks the sorting
    //    location.reload();
    //}
}