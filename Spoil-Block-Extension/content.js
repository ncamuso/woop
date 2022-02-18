//alert('Welcome to Spoil Block')

//const myElement = document.getElementById("video-title");
//    myElement.innerText = "spoiler";

async function IsLoaded() {
    let el = document.getElementById("video-title");
    if (el) {
        console.log(el);
        el.innerHTML += "spoiler";
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

asyncCall();