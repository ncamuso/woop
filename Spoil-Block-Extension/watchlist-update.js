var titles = [];

document.querySelectorAll('[name=ddButton]').forEach( element => {
    element.addEventListener('change', updateWatchlist);
});

function updateWatchlist() {
    console.log("Updating watchlist...");
    chrome.storage.local.clear();
    try {
        document.querySelector('#sortTable').querySelectorAll('tr').forEach( (element, index) => {
            if (index === 0) return;

            var title = element.querySelector('.imageandname').textContent.trim();
            var watchStatus = element.querySelector('[name=ddButton]').textContent;

            if (watchStatus != 'Completed') {
                titles.push(title);
            }

            //titles.push(element.textContent.trim());
            //console.log(element);
            //console.log(element.querySelector('[name=ddButton]').textContent);
            //if (element)
            //console.log(element.querySelector('.imageandname').textContent.trim());
            //element.querySelector()
            
        });
    } catch (error) {
        console.log(error);
    }
        
    chrome.storage.local.set({"watchlist" : titles}, function() {
        console.log("Watchlist updated!");
        console.log(titles);
    });
}

updateWatchlist();