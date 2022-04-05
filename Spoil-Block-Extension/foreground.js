console.log("hello from foreground");

const first = document.createElement('button');
first.innerText = "SET DATA";
first.id = "first";

const second = document.createElement('button');
second.innerText = "SHOUTOUT TO BACKEND";
second.id = "second";

document.querySelector('ytd-app').appendChild(first);
document.querySelector('ytd-app').appendChild(second);