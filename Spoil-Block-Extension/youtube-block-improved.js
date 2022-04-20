var videoTitles = [];
var spoilersOnPage = 0;

function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    element.style.filter = 'blur(10px)';
}

function checkHomePageThumbnail(title) {
    //var thumbnail = title.closest(".style-scope ytd-rich-grid-media").querySelector('#img');
    var thumbnail = title.closest("#dismissible").querySelector('#img');
    return thumbnail;
}

function checkSearchPageThumbnail(title) {
    var thumbnail = title.closest(".style-scope ytd-video-renderer").querySelector('#img');
    return thumbnail;
}

function checkWatchPageThumbnail(title) {
    var thumbnail = title.closest(".style-scope ytd-compact-video-renderer").querySelector('#img');
    return thumbnail;
}

function checkSpoiler(title) {
    //let title = element.querySelector("#video-title");
    //let title = element.querySelector('#video-title');
    //console.log(title.closest(".style-scope ytd-rich-grid-media").querySelector('#img'));
    var thumbnail;
    // try {
    //     thumbnail = checkHomePageThumbnail(title);
    // } catch (error) {
    //     try {
    //         thumbnail = checkSearchPageThumbnail(title);
    //     } catch (error) {
    //         try {
    //             thumbnail = checkWatchPageThumbnail(title);
    //         } catch (error) {
    //             console.log(title);
    //             return false;
    //         }
    //     }
    //     //console.log('checking "style-scope ytd-video-renderer"');
    // } 
    try {
        thumbnail = checkHomePageThumbnail(title);
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
    //put try catch back here if shit breaks
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
    //put try catch back here if shit breaks
    // try {
    //     div = document.querySelector('#video-title').closest('#contents');
    // } catch (error) {
    //     console.log('div was empty');
    //     setTimeout(function() {
    //         getContents();
    //     }, 100);
    // }
    //var div = document.getElementById('contents');
    //var div = document.querySelector('#contents');
    //var div = document.querySelector('#video-title').closest('#contents');
    if (div === null)
    {
        console.log("div was somehow still null lol");
        // console.log('div was empty');
        // setTimeout(function() {
        //     getContents();
        // }, 100);
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
                //videoTitles.push(element);
            });
            // for (let i = 0; i < 9; i++) {
            //     videoTitles.push(titles[i]);
            // }
        } catch (error) {
        //    console.log(error)
        }
        //console.log(videoTitles);

        //document.getElementById('contents').addEventListener("DOMNodeInserted", function (node) {
        div.addEventListener("DOMNodeInserted", function (node) {
            if (node.path.some(e => e.id === 'video-title')) {
                if (node.path[0].nodeName === '#text') {
                    //console.log(node.path);
                    //var newItem = node.path[0].nodeValue;
                    var newItem = node.path[1];
                    if (videoTitles.indexOf(newItem) === -1) {
                        videoTitles.push(newItem);
                        if (checkSpoiler(newItem)) {
                            spoilersOnPage++;
                        }
                    }
                    //videoTitles.indexOf(newItem) === -1 ? videoTitles.push(newItem) : console.log();
                    /*

                    */
                    //console.log("videos on screen: " + document.querySelectorAll('#video-title').length);
                    //console.log("ARRAY OF VIDEO TITLES: "+videoTitles);
                    //console.log("LENGTH OF VIDEO TITLES ARRAY: " + videoTitles.length);
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