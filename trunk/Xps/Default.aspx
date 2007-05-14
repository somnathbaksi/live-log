<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Mock_Ups_Default" Title="Untitled Page"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="left">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
            CollapseControlID="InfoPanelTitle" ExpandControlID="InfoPanelTitle" TargetControlID="Panel1">
        </ajaxToolkit:CollapsiblePanelExtender>
        <asp:Panel ID="InfoPanelTitle" runat="server" CssClass="collapsePanelHeader">
            <asp:Label ID="Label1" runat="server" meta:resourceKey="Lbl_InfoPane" ></asp:Label>
            <div><%=Resources.Default.Footer %>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel">
            <asp:LinkButton ID="LinkButton2" runat="server">My Account</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton1" runat="server">Publish Information</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton3" runat="server">Shor Message For You</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton4" runat="server">Your Published Items</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton5" runat="server">Saved Search</asp:LinkButton><br />
        </asp:Panel>
        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
            CollapseControlID="Panel5" ExpandControlID="Panel5" TargetControlID="Panel3">
        </ajaxToolkit:CollapsiblePanelExtender>
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="125px">
            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Most Recent</asp:LinkButton><br />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" CssClass="collapsePanelHeader">
            <asp:Label ID="Label2" runat="server" Text="YouTube Site"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server"  CssClass="collapsePanel">
            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" Width="102px">Top Viewed</asp:LinkButton></asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Height="50px" Width="125px">
            <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">Mofile</asp:LinkButton></asp:Panel>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <div>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="center">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="388px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="Live5.Xps.ArticleComponent.ArticleService">Article</asp:ListItem>
                <asp:ListItem Value="Live5.Xps.Framework.BuiltIn.BuiltInService">All</asp:ListItem>
                <asp:ListItem Value="Live5.Xps.Framework.External.ExternalService">External</asp:ListItem>
                <asp:ListItem Value="Live5.Xps.MediaComponent.MediaService">Media</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search&Save" />
        </div>
        <div>
            <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" runat="server"
                TargetControlID="FeedsPanel">
            </ajaxToolkit:UpdatePanelAnimationExtender>
            <asp:UpdatePanel ID="FeedsPanel" runat="server">
                <contenttemplate>
                    <div id="feedPanel" class="feedsPanel">
                        <asp:Literal ID="Literal1" runat="server" __designer:wfdid="w3"></asp:Literal>
                    </div>
                </contenttemplate>
                <triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="LinkButton6" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="LinkButton7" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="LinkButton8" EventName="Click"></asp:AsyncPostBackTrigger>
                </triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
