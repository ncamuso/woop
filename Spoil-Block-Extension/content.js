function blurElement (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function checkSpoiler(element) {
    if(element.innerHTML.toString().toLowerCase().includes('spoiler')) {
        blurElement(element);
    }
}

async function IsLoaded() {
    let el = document.getElementById("video-title");
        
    if (el) {
        let els = document.querySelectorAll('[id=video-title]');
        els.forEach(
            function(currentValue) {
                checkSpoiler(currentValue);
            }
        );
    } else {
        console.log("Not yet loaded");
    }
}

function pageWait() {
return new Promise(resolve => {
    setTimeout(() => {
    IsLoaded();
    }, 1000);
});
}
  
async function asyncCall() {
    console.log('calling');
    const result = await pageWait();

    console.log(result);
}


//contentEl.addEventListener("DOMSubtreeModified", test)

asyncCall();
