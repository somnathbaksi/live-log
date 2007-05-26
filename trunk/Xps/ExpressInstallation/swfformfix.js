/**
 * SWFFormFix v1.0.0: SWF ExternalInterface() Form Fix - http://http://www.teratechnologies.net/stevekamerman/
 *
 * SWFFormFix is (c) 2007 Steve Kamerman and is released under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 *
 * Project sponsored by Tera Technologies - http://www.teratechnologies.net/
 * 
 * Usage:
 * ------------------------------------------------------------
 * There are two ways to use SWFFormFix, Auto and Manual mode.
 * To use either method you need to include this file in the 
 * HEAD section of your page like this: 

<script src="swfformfix.js" type="text/javascript"></script>

 * 
 * --> Auto Mode:
 * This will attempt to find every Flash Movie that you have on
 * the page and apply the fix to each of them.  To use auto mode
 * put the following code before the </body> tag. More specifically
 * it needs to be AFTER your last Flash object.

<script type="text/javascript">
// <![CDATA[
	SWFFormFixAuto();
// ]]>
</script>

 * 
 * --> Manual Mode:
 * This lets you fix just a single Flash object if you don't want
 * the auto mode to try to fix every Flash object on the page.
 * This mode is faster than the auto mode and may work better in
 * some situations.  To use manual mode put the following code
 * after the Flash object you want to fix, where "myFlashObject"
 * is the ID of the Flash Object:

Example for normal EMBED style:

<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="200" height="100" id="myFlashObject" align="middle">
<param name="movie" value="myMovie.swf" />
<param name="quality" value="high" />
<embed src="myMovie.swf" quality="high" width="200" height="100" name="myFlashObject" type="application/x-shockwave-flash" />
</object>

<script type="text/javascript">
// <![CDATA[
SWFFormFix("myMovieObjectName");
// ]]>
</script>

Example for SWFObject style:

<div id="flashcontent" style="width:200px;height:100px;">This is replaced by the Flash movie.</div>
<script type="text/javascript">
// <![CDATA[
// Please note that the ID that you need to use for SWFFormFix() is the second argument in SWFObject().
var so = new SWFObject("myMovie.swf", "myFlashObject","200", "100", "6.0.0", "#ffffff");
so.addParam("quality", "high");
so.write("flashcontent");
SWFFormFix("myFlashObject");
// ]]>
</script>

 * 
 * Changelog:
 * ------------------------------------------------------------
 * 
 * v1.0.0
 *   Added the SWFFormFixAuto() function, very well optimized and fast.
 * 
 * v0.2.0
 *   Changed helper element from <input> element to hidden <div> element
 *
 * v0.1.0
 *   Initial release.
 */
 
SWFFormFixAuto = function(){
	if(navigator.appName.toLowerCase() != "microsoft internet explorer")return true;
	var objects = document.getElementsByTagName("object");
	if(objects.length == 0) return true;
	for(i=0;i<objects.length;i++){
		// here's all the objects on the page, now lets find the flash objects
		if(objects[i].classid == "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"){
			// this is a flash movie, apply the fix
			window[objects[i].id] = objects[i];
		}
	}
	var out = '';
	return true;
}
SWFFormFix = function(swfname){
	if(navigator.appName.toLowerCase() != "microsoft internet explorer")return false;
	var testnodename = "SWFFormFixTESTER";
	document.write('<div id="'+testnodename+'" onclick="SWFFormFixCallback(this,\''+swfname+'\');return false;" style="display:none">&nbsp;</div>');
	document.getElementById(testnodename).onclick();
}
SWFFormFixCallback = function (obj,swfname){
	var path = document;
	var error = false;
	var testnode = obj;
	while(obj = obj.parentNode){
		if(obj.nodeName.toLowerCase() == "form"){
			if(obj.name != undefined && obj.name != null && obj.name.length > 0){
				path = path.forms[obj.name];
			}else{
				alert("Error: one of your forms does not have a name!");
				error = true;
			}
		}
	}
	testnode.parentNode.removeChild(testnode);
	if(error) return false;
	window[swfname]=path[swfname];
	return true;
}