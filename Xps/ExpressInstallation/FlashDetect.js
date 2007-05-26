
// -----------------------------------------------------------------------------
// Globals
// Major version of Flash required
var requiredMajorVersion = 8;
// Minor version of Flash required
var requiredMinorVersion = 0;
// Minor version of Flash required
var requiredRevision = 0;
// -----------------------------------------------------------------------------

function WriteFlash(flashfile,f_width,f_height,f_vars){

// Version check for the Flash Player that has the ability to start Player Product Install (6.0r65)
var hasProductInstall = DetectFlashVer(6, 0, 65);

// Version check based upon the values defined in globals
var hasReqestedVersion = DetectFlashVer(requiredMajorVersion, requiredMinorVersion, requiredRevision);

// Check to see if a player with Flash Product Install is available and the version does not meet the requirements for playback
if ( hasProductInstall && !hasReqestedVersion ) {
	// MMdoctitle is the stored document.title value used by the installation process to close the window that started the process
	// This is necessary in order to close browser windows that are still utilizing the older version of the player after installation has completed
	// DO NOT MODIFY THE FOLLOWING FOUR LINES
	// Location visited after installation is complete if installation is required
	var MMPlayerType = (isIE == true) ? "ActiveX" : "PlugIn";
	var MMredirectURL = window.location;
	document.title = document.title.slice(0, 47) + " - Flash Player Installation";
	var MMdoctitle = document.title;

	AC_FL_RunContent(
		"src", "ExpressInstallation/playerProductInstall",
		"FlashVars", "MMredirectURL="+MMredirectURL+'&MMplayerType='+MMPlayerType+'&MMdoctitle='+MMdoctitle+"",
		"width", "550",
		"height", "300",
		"align", "middle",
		"id", "detectionExample",
		"quality", "high",
		"bgcolor", "#3A6EA5",
		"name", "detectionExample",
		"allowScriptAccess","sameDomain",
		"type", "application/x-shockwave-flash",
		"pluginspage", "http://www.adobe.com/go/getflashplayer"
	);
} else if (hasReqestedVersion) {
	// if we've detected an acceptable version
	// embed the Flash Content SWF when all tests are passed
	AC_FL_RunContent(
			"src", flashfile,
			"FlashVars",f_vars,
			"width", f_width,
			"height", f_height,
			"align", "middle",
			"id", "detectionExample",
			"quality", "high",
			"bgcolor", "#FFFFFF",
			"wmode","transparent",
			"name", "detectionExample",
			"allowScriptAccess","sameDomain",
			"type", "application/x-shockwave-flash",
			'codebase', 'http://fpdownload.macromedia.com/get/flashplayer/current/swflash.cab',
			"pluginspage", "http://www.adobe.com/go/getflashplayer"
	);
} else {  // flash is too old or we can't detect the plugin
	var alternateContent = 'Alternate HTML content should be placed here.<BR>'
	+ 'This content requires the Adobe Flash Player. '
	+ '<a href=http://www.adobe.com/go/getflash/>Get Flash</a>';
	document.write(alternateContent);  // insert non-flash content
}
}