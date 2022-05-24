console.log("hi from background");

let hasSetYouTubeListener = false;
let hasSetSpoilBlockListner = false;

chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        var opt = {
        type: 'basic',
        title: 'Watchlist Updated',
        message: 'Changes to your watchlist have been saved',
        iconUrl: 'images/48_SpoilBlockLogo.png'
    }
    chrome.notifications.create(opt);
      console.log(sender.tab ?
                  "from a content script:" + sender.tab.url :
                  "from the extension");
      if (request.greeting === "hello")
        sendResponse({farewell: "goodbye"});
    }
  );

chrome.tabs.onUpdated.addListener(tab => {
    chrome.tabs.get(tab, current_tab_info => {
        if (/^https:\/\/www\.youtube/.test(current_tab_info.url) && current_tab_info.status === "complete") {
            console.log(current_tab_info);
            console.log("executing script");
            chrome.scripting.executeScript({
                target: {tabId: current_tab_info.id},
                files: ['youtube-block-improved.js']
            });
        }
        else if (current_tab_info.url.includes('spoilblock.azurewebsites.net/Watchlist'))
        {
            console.log('hello watchlist');
            hasSetSpoilBlockListner = true;
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