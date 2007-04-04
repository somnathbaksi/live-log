// JScript File
function LoadFeed(feedUrl){
var feedFrame=document.getElementById("feed");
feedFrame.src="atom.ashx?q="+feedUrl;

}
