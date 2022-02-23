//const myElement = document.getElementById("video-title");
//    myElement.innerText = "spoiler";

function blurElement (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}
function print(value) {
    console.log(value);
}

async function IsLoaded() {
    let el = document.getElementById("video-title");
        
    if (el) {
        console.log(el);
        //el.innerHTML += "spoiler";
        blurElement(el);
        let els = document.querySelectorAll('[id=video-title]');
        els.forEach(
            function(currentValue) {
                blurElement(currentValue);
            }
        );

        console.log(els);
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

// expected output: "resolved"
}


//contentEl.addEventListener("DOMSubtreeModified", test)

asyncCall();

// DOM Subtree Modified
