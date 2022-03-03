function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    element.style.filter = 'blur(10px)';
}

function checkSpoiler(element) {
    let title = element.querySelector("#video-title");
    let thumbnail = element.querySelector("#img")

    if(title.innerHTML.toString().toLowerCase().includes('spoiler')) {
        blurTitle(title);
        blurThumbnail(thumbnail);
    }
}

async function IsLoaded() {
    document.getElementById("contents").addEventListener("DOMSubtreeModified", function (event) {
        console.log("modified");
        if (el) {
            let els = document.querySelectorAll('[id=dismissible]');
            els.forEach(
                function(currentValue) {
                    checkSpoiler(currentValue);
                }
            );
        } else {
            console.log("Not yet loaded");
        }
    });
    //------------------------------------------------

    let el = document.getElementById("video-title");
        
    
}

function pageWait() {
return new Promise(resolve => {
    setTimeout(() => {
    IsLoaded();
    }, 500);
});
}
  
async function asyncCall() {
    console.log('calling');
    const result = await pageWait();

    console.log(result);
}


//contentEl.addEventListener("DOMSubtreeModified", test)

asyncCall();
