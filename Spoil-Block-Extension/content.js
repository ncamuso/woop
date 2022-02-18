//alert('Welcome to Spoil Block')

//const myElement = document.getElementById("video-title");
//    myElement.innerText = "spoiler";

async function IsLoaded() {
    let el = document.getElementById("video-title");
    if (el) {
        console.log(el);
        //el.innerHTML += "spoiler";
        el.style.color = 'transparent';
        el.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
    } else {
        console.log("Not yet loaded");
    }
}

function pageWait() {
return new Promise(resolve => {
    setTimeout(() => {
    IsLoaded();
    }, 100);
});
}
  
async function asyncCall() {
console.log('calling');
const result = await pageWait();

console.log(result);

// expected output: "resolved"
}

asyncCall();