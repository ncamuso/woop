let videoTitles = [];
let spoilersOnPage = 0;

function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    element.style.filter = 'blur(10px)';
}

function checkSpoiler(title) {
    //let title = element.querySelector("#video-title");
    //let title = element.querySelector('#video-title');
    //console.log(title.closest(".style-scope ytd-rich-grid-media").querySelector('#img'));
    var thumbnail = title.closest(".style-scope ytd-rich-grid-media").querySelector('#img');

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
    try {
        for (let i = 0; i < 9; i++) {
            videoTitles.push(document.querySelectorAll('#video-title')[i]);
        }
    } catch (error) {
        console.log(error)
    }
    
    let div = document.getElementById('contents');
    if (div === null)
    {
        console.log('div was empty');
        setTimeout(function() {
            getContents();
        }, 100);
    } else {
        console.log(div);
        document.getElementById('contents').addEventListener("DOMNodeInserted", function (node) {
            if (node.path.some(e => e.id === 'video-title')) {
                if (node.path[0].nodeName === '#text') {
                    console.log(node.path);
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
                    console.log("videos on screen: " + document.querySelectorAll('#video-title').length);
                    console.log("ARRAY OF VIDEO TITLES: "+videoTitles);
                    console.log("LENGTH OF VIDEO TITLES ARRAY: " + videoTitles.length);
                    console.log("Spoilers on page: " + spoilersOnPage);
                }
            }
        });
    }
}

$( "document" ).ready( getContents() );