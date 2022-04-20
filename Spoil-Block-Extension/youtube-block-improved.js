var videoTitles = [];
var spoilersOnPage = 0;

function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    element.style.filter = 'blur(10px)';
}

function checkThumbnail(title) {
    var thumbnail = title.closest("#dismissible").querySelector('#img');
    return thumbnail;
}

function checkSpoiler(title) {
    var thumbnail;

    try {
        thumbnail = checkThumbnail(title);
    } catch (error) {
        console.log(error);
    }
    let titleText = title.innerHTML.toString().toLowerCase();
    let isSpoiler = false;

    if (titleText.includes('spoiler') && !titleText.includes('no spoiler')) { isSpoiler = true; }
    if (titleText.includes('spoiler-free') || titleText.includes('spoiler free') || titleText.includes('non-spoiler')) {isSpoiler = false; }

    if(isSpoiler) {
        blurTitle(title);
        blurThumbnail(thumbnail);
    }
    return isSpoiler;
    
}

function getContents() {
    console.log('calling');

    chrome.storage.local.get(['watchlist'], function(result) {
        console.log("Retrieved watchlist from storage");
        console.log(result);
    })

    try {
        if (location.href === "https://www.youtube.com/") {
            console.log("on homepage");
            var div = document.querySelector('#contents');
        } else {
            var div = document.querySelector('#video-title').closest('#contents');
        }
    } catch (error) {
        console.log('div was empty');
        setTimeout(function() {
            getContents();
        }, 100);
    }
    
    if (div != null) {
        addListenerToDom(div);
    }
}

function addListenerToDom(div) {
    console.log('adding listner');

    if (div === null)
    {
        console.log("div was somehow still null lol");
    } else {
        try {
            var titles = document.querySelectorAll('#video-title');
            console.log(titles);
            titles.forEach(element => {
                if (videoTitles.indexOf(element) === -1) {
                    if (checkSpoiler(element)) {
                        spoilersOnPage++;
                    }
                    videoTitles.push(element);
                }
            });
        } catch (error) {
            console.log(error)
        }

        div.addEventListener("DOMNodeInserted", function (node) {
            if (node.path.some(e => e.id === 'video-title')) {
                if (node.path[0].nodeName === '#text') {
                    //console.log(node.path);
                    var newItem = node.path[1];
                    if (videoTitles.indexOf(newItem) === -1) {
                        videoTitles.push(newItem);
                        if (checkSpoiler(newItem)) {
                            spoilersOnPage++;
                        }
                    }

                    console.log("Spoilers on page: " + spoilersOnPage);
                }
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
}

$( "document" ).ready( getContents() );