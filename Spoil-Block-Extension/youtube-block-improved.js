let videoTitles = [];

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
                    videoTitles.indexOf(newItem) === -1 ? videoTitles.push(newItem) : console.log();
                    /*

                    */
                    console.log("videos on screen: " + document.querySelectorAll('#video-title').length);
                    console.log("ARRAY OF VIDEO TITLES: "+videoTitles);
                    console.log("LENGTH OF VIDEO TITLES ARRAY: " + videoTitles.length);
                }
            }
        });
    }
}

$( "document" ).ready( getContents() );