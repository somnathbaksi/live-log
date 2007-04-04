<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true" CodeFile="MediaView.aspx.cs" Inherits="MediaView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
            <!--[if !IE]> Firefox and others will use outer object -->
            <object type="application/x-shockwave-flash" data="Swf/liveplayer.swf" width="550"
                height="500">
                <param name="movie" value="Swf/liveplayer.swf" />
                <param name="quality" value="high" />
                <param name="loop" value="false" />
                <param name="wmode" value="transparent" />
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="FlashVars" value="<%=FlashVars%>" />
                <!--<![endif]-->
                <!-- MSIE (Microsoft Internet Explorer) will use inner object -->
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://active.macromedia.com/flash2/cabs/swflash.cab#version=4,0,0,0"
                    width="550" height="500">
                    <param name="src" value="Swf/liveplayer.swf" />
                    <param name="quality" value="high" />
                    <param name="loop" value="false" />
                    <param name="wmode" value="transparent" />
                    <param name="allowScriptAccess" value="sameDomain" />
                    <param name="FlashVars" value="<%=FlashVars%>" />
                    <p>
                        This browser does not have a Media Player Plug-in.
                        <br />
                        <a href="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                            rel="external">Get the Flash Player Plug-in here. </a>
                    </p>
                </object>
                <!--[if !IE]> close outer object -->
            </object>
            <!--<![endif]-->
        </div>
        <div id="player">
            <script type="text/ecmascript">
<!--
WriteFlash("swf/liveplayer","400","300","feed=http://localhost:8080/Xps/atom.ashx?q=254c84d2-80ef-48f7-9f50-2ca0acfad155");
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

