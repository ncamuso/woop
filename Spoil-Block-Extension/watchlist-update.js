console.log("hello from watchlist-update");

var titles = [];

try {
    document.querySelectorAll('.imageandname').forEach( element => {
        titles.push(element.textContent.trim());
    });
} catch (error) {
    console.log(error);
}

//console.log(titles);

chrome.storage.local.set({"watchlist" : titles}, function() {
    console.log("Set watchlist to storage.");
    console.log(titles);
})
