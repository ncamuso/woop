console.log("hi from background");

let hasSetYouTubeListener = false;

chrome.tabs.onUpdated.addListener(tab => {
    chrome.tabs.get(tab, current_tab_info => {
        if (/^https:\/\/www\.youtube/.test(current_tab_info.url) && current_tab_info.status === "complete") {
            console.log(current_tab_info);
            hasSetYouTubeListener = true;
            chrome.scripting.executeScript({
                target: {tabId: current_tab_info.id},
                files: ['youtube-block-improved.js']
            });
        }
        else if (current_tab_info.url.includes('spoilblock.azurewebsites.net/Watchlist'))
        {
            console.log('hello watchlist');
            chrome.scripting.executeScript({
                target: {tabId: current_tab_info.id},
                files: ['watchlist-update.js']
            });
        }
    });
});


// chrome.tabs.onActivated.addListener(tab => {
//     chrome.tabs.get(tab.tabId, current_tab_info => {
//         if (/^https:\/\/www\.youtube/.test(current_tab_info)) {
//             chrome.tabs.executeScript(null, {file: './foreground.js'}, () => console.log('i injected'));
//         }
//     });
// });