let videoTitles = [];

function getContents() {
    console.log('calling');
    try {
        for (let i = 0; i < 9; i++) {
            videoTitles.push(document.querySelectorAll('#video-title')[i].innerHTML);
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
        document.getElementById('contents').addEventListener("DOMNodeInserted", function (event) {
            if (event.path.some(e => e.id === 'video-title')) {
                if (event.path[0].nodeName === '#text') {
                    console.log(event.path);
                    var newItem = event.path[0].nodeValue;
                    videoTitles.indexOf(newItem) === -1 ? videoTitles.push(newItem) : console.log();
                    console.log("videos on screen: " + document.querySelectorAll('#video-title').length);
                    console.log("ARRAY OF VIDEO TITLES: "+videoTitles);
                    console.log("LENGTH OF VIDEO TITLES ARRAY: " + videoTitles.length);
                }
            }
        });
    }
}

$( "document" ).ready( getContents() );