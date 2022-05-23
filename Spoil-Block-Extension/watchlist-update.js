var titles = [];
let notified = false;

document.querySelectorAll('[name=ddButton]').forEach( element => {
    var observer = new MutationObserver(function(mutations) {
        mutations.forEach(function(mutation) {
          if (mutation.attributeName === "data-status") {
            updateWatchlist();
          }
        });
      });

    observer.observe(element, {
        attributes: true //configure it to listen to attribute changes
      });
});

async function updateWatchlist() {
    console.log("Updating watchlist...");
    chrome.storage.local.clear();
    titles = [];
    try {
        document.querySelector('#sortTable').querySelectorAll('tr').forEach( (element, index) => {
            if (index === 0) return;

            var title = element.querySelector('.imageandname').textContent.trim();
            var watchStatus = element.querySelector('[name=ddButton]').textContent;
            console.log(watchStatus);
            if (watchStatus != 'Completed') {
                titles.push(title);
            }
        });
    } catch (error) {
        console.log(error);
    }
        
    chrome.storage.local.set({"watchlist" : titles}, function() {
        console.log("Watchlist updated!");
        notification();

        console.log(titles);
    });
}

function notification() {
    
    chrome.runtime.sendMessage({greeting: "hello"}, function(response) {
        console.log(response.farewell);
      });
}

document.addEventListener('DOMContentLoaded', updateWatchlist());