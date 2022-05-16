
document.querySelector('#goto-watchlist-btn').addEventListener('click', function () {
    chrome.tabs.create({
        url: 'https://spoilblock.azurewebsites.net/Watchlist'
    });
});

async function getWatchlist() {
    chrome.storage.local.get(['watchlist'], function(result) {
        console.log("getting watchlist");
        result;
        //getContents();
        console.log(result);
        return createWatchlistList(result);
    });
}

async function createWatchlistList(result) {
    var watchlist = Object.values(result)[0];
    console.log(watchlist);
    var ul = document.createElement('ul');
    ul.setAttribute('class', 'list-group list-group-flush');

    document.getElementById('watchlist-list').appendChild(ul);

    watchlist.forEach(renderWatchlist);

    //watchlist.forEach(renderWatchlist);
    function renderWatchlist(element, index, arr) {
        var li = document.createElement('li');
        li.setAttribute('class', "list-group-item");

        ul.appendChild(li);
        li.innerHTML = li.innerHTML + element;
    }
}

getWatchlist();