<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="MediaView.aspx.cs" Inherits="MediaView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input id="feedUrl" type="hidden" value="<%=FeedUrl %>" />
    <div>
    </div>
    <div id="player">
        <script type="text/ecmascript">
        <!--
        WriteFlash("swf/liveplayer","550","500","a=b");
        SWFFormFix("detectionExample");
        // -->
        </script>

        <noscript>
            Provide alternate content for browsers that do not support scripting or for those
            that have scripting disabled. Alternate HTML content should be placed here. This
            content requires the Adobe Flash Player and a browser with JavaScript enabled. <a
                href="http://www.adobe.com/go/getflash/">Get Flash</a>
        </noscript>
    </div>
</asp:Content>
