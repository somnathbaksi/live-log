<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="Publish.aspx.cs" Inherits="Publish" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <div>
            <!--[if !IE]> Firefox and others will use outer object -->
            <object type="application/x-shockwave-flash" data="Swf/LiveUpload.swf" width="550"
                height="100">
                <param name="movie" value="Swf/LiveUpload.swf" />
                <param name="quality" value="high" />
                <param name="loop" value="false" />
                <param name="wmode" value="transparent" />
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="FlashVars" value="<%=FlashVars%>" />
                <!--<![endif]-->
                <!-- MSIE (Microsoft Internet Explorer) will use inner object -->
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://active.macromedia.com/flash2/cabs/swflash.cab#version=4,0,0,0"
                    width="550" height="100">
                    <param name="src" value="Swf/LiveUpload.swf" />
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
        <div style="width: 663px; height: 252px">
            &nbsp; &nbsp;
            <div style="width: 512px; height: 100px">
                &nbsp;<asp:TextBox ID="TextBox3" runat="server">title</asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine">Summary</asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Article</asp:ListItem>
                    <asp:ListItem>Media</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList2" runat="server" Visible="false">
                    <asp:ListItem>video/x-flv</asp:ListItem>
                    <asp:ListItem>audio/mpeg</asp:ListItem>
                    <asp:ListItem>image/jpeg</asp:ListItem>
                </asp:DropDownList></div>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="203px" TextMode="MultiLine" Width="500px">content</asp:TextBox><br />
            <div style="width: 478px; height: 100px">
                <asp:TextBox ID="TextBox4" runat="server" Height="110px" Width="464px"></asp:TextBox></div>
        </div>
    </div>
</asp:Content>
