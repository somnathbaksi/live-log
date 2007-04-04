<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Mock_Ups_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="nav">
        <asp:LinkButton ID="LinkButton2" runat="server">My Account</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton1" runat="server">Publish Information</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton3" runat="server">Shor Message For You</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton4" runat="server">Your Published Items</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton5" runat="server">Saved Search</asp:LinkButton><br />
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
    <div id="Content" style="float: left; height: 800px">
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
        <div style="float: left; width: 80%; height: auto;">
            <iframe id="feed" src="Atom.ashx?q=<%=QueryId %>&style=true" width="600px" height="800px">ddd</iframe>
        </div>
    </div>
</asp:Content>
