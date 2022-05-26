//location.reload();
var videoTitles = [];
var spoilersOnPage = 0;
var watchList = [];
getWatchlist();

function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    if (element) {
        element.style.filter = 'blur(10px)';
    }
}

function checkThumbnail(title) {
    var thumbnail = title.closest("#dismissible");
    if (thumbnail) {
        thumbnail = thumbnail.querySelector('#img');
    }
    return thumbnail;
}

function checkSpoiler() {
    var isSpoiler = false;

    if (titleText.includes('spoiler') && !titleText.includes('no spoiler')) { isSpoiler = true; }
    if (titleText.includes('spoiler-free') || titleText.includes('spoiler free') || titleText.includes('non-spoiler')) {isSpoiler = false; }
    return isSpoiler;
}

function checkVideosAgainstWatchlist(title) {
    var thumbnail;

    try {
        thumbnail = checkThumbnail(title);
    } catch (error) {
        console.log(error);
    }

    var titleText = title.innerText.toString().toLowerCase();
    var isSpoiler = false;
    console.log(watchList);
    Object.values(watchList)[0].forEach( element => {
        //console.log("current element is: "+ element.toString().toLowerCase() + " current title is: " + titleText);
        if (titleText.includes(element.toString().toLowerCase())) {
            isSpoiler = true;
        }
    })
    // for (let i = 0; i < Object.values(watchList).length; i++) {
    //     const element = Object.values(watchList)[i];
    //     console.log(element[i]);
    // }

    // Object.values(watchList).forEach(element => {
    //     console.log("current element is: "+ element.toString().toLowerCase() + "current title is: " + titleText);
    //     if (titleText.includes(element.toString().toLowerCase())) {
    //         isSpoiler = true;
    //     }
    // });

    if(isSpoiler && thumbnail != null) {
        blurTitle(title);
        blurThumbnail(thumbnail);
    }
    return isSpoiler;
    
}

function sleep(ms) {
    return new Promise((resolve) => {
      setTimeout(resolve, ms);
    });
}

async function getWatchlist() {
    chrome.storage.local.get(['watchlist'], function(result) {
        console.log("getting watchlist");
        watchList = result;
        getContents();
    });
}

async function getContents() {

    console.log('calling');
    var div;
    var onWatchPage = false;
    try {
        if (location.href === "https://www.youtube.com/") {
            console.log("on homepage");
            div = document.querySelector('#contents');
        } else if (location.href.includes("https://www.youtube.com/results")) {
            console.log("on results page");
            div = document.querySelector('#video-title').closest('#contents').parentElement.closest('#contents');
        } else {
            console.log("on watch page");
            div = document.querySelector('#video-title').closest('#items');
            onWatchPage = true;
        }
    } catch (error) {
        console.log('div was empty');
        setTimeout(function() {
            getContents();
        }, 100);
    }
    
    if (div != null) {
        addListenerToDom(div);
    } else {
        await sleep(1000);
        getContents();
    }
    //test
}

function addListenerToDom(div) {

    console.log('adding listner');
    console.log(div.closest('.style-scope ytd-section-list-renderer'));
    if (div === null)
    {
        console.log("div was somehow still null lol");
    } else {
        try {
            var titles = document.querySelectorAll('#video-title');
            console.log(titles);
            titles.forEach(element => {                
                //element.style.color = 'red';
                
                if (videoTitles.indexOf(element) === -1) {
                    if (checkVideosAgainstWatchlist(element)) {
                        spoilersOnPage++;
                    }
                    videoTitles.push(element);
                }
            });
        } catch (error) {
            console.log('Error reading title from inital load. ' + error)
        }

        div.addEventListener("DOMNodeInserted", function (node) {
            try {
                if (node.path.some(e => e.id === 'video-title')) {
                    //console.log(node);
                    if (node.path[0].nodeName === '#text') {
                        //console.log(node.path);
                        var newItem = node.path[1];
                        //newItem.style.color = 'red';
                        if (videoTitles.indexOf(newItem) === -1) {
                            videoTitles.push(newItem);
                            if (checkVideosAgainstWatchlist(newItem)) {
                                spoilersOnPage++;
                            }
                        }
    
                        console.log("Spoilers on page: " + spoilersOnPage);
                    }
                }
            } catch (error) {
                console.log(error);
            }
            
        });
    }
}

var lastUrl = location.href; 
new MutationObserver(() => {
  const url = location.href;
  if (url !== lastUrl) {
    lastUrl = url;
    onUrlChange();
  }
}).observe(document, {subtree: true, childList: true});


function onUrlChange() {
    location.reload();
    videoTitles = [];
    spoilersOnPage = 0;
    watchList = [];
    getContents();
}
//setWatchlist();

//$( "document" ).ready( getContents() );
//getContents();