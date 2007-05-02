﻿// JScript File
function LoadFeed(feedUrl){
var url="atom.ashx?q="+feedUrl;
GetWebRequest(url,"feedPanel");
}
var displayElement;


//function pageLoad()
//{
//GetWebRequest('getTarget.htm', 'ResultId0');
//PostWebRequest('postTarget.aspx', 'ResultId0')
//}


function GetWebRequest(getPage, HTMLtarget)
{
    displayElement = $get(HTMLtarget);
    SetWaitInfo();
    var wRequest =  new Sys.Net.WebRequest(); 
    wRequest.set_url(getPage);  
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(OnWebRequestCompleted)
    wRequest.invoke();      
}


function PostWebRequest(postPage, HTMLtarget)
{
    displayElement = $get(HTMLtarget);
    var wRequest =  new Sys.Net.WebRequest();
    wRequest.set_url(postPage); 
    wRequest.set_httpVerb("POST");
    var body = "Message=Javascript generated POST parameter"
    wRequest.set_body(body);
    wRequest.get_headers()["Content-Length"] = body.length;
    wRequest.add_completed(OnWebRequestCompleted);
    wRequest.invoke();  
}
function SetWaitInfo(){
 if (document.all)
          {
          displayElement.innerHTML = "Loading...";
          }
       else // Firefox
          {
          displayElement.textContent = "Loading...";
          }
       

}
function OnWebRequestCompleted(executor, eventArgs) 
{
    if (executor.get_responseAvailable()) 
       {  
       // displayElement.innerHTML = "";               
       if (document.all)
          {
          displayElement.innerHTML = executor.get_responseData();
          }
       else // Firefox
          {
          displayElement.textContent = executor.get_responseData();
          }
       }
    else
       {
       if (executor.get_timedOut())
          {
          alert("Timed Out");
          }
        else
          {
          if (executor.get_aborted())
                alert("Aborted");
          }
    }
}

if (typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();