var titles = [];
let notified = false;

document.querySelectorAll('[name=ddButton]').forEach( element => {
    //element.addEventListener("click", updateWatchlist);
    var observer = new MutationObserver(function(mutations) {
        mutations.forEach(function(mutation) {
          if (mutation.type === "attributes") {
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

        if (!notified) {
            notification();
            notified = true;
        }
        console.log(titles);
    });
}

function notification() {
    
    chrome.runtime.sendMessage({greeting: "hello"}, function(response) {
        console.log(response.farewell);
      });
}

const interval = setInterval(function() {
    notified = false;
  }, 500);
 
 //clearInterval(interval);

document.addEventListener('DOMContentLoaded', updateWatchlist());