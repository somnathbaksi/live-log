<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="QueryEditor.aspx.cs" Inherits="QueryEditor" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="388px"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="Live5.Xps.ArticleComponent.ArticleService">Article</asp:ListItem>
        <asp:ListItem Value="Live5.Xps.Framework.BuiltIn.BuiltInService">BuiltIn</asp:ListItem>
        <asp:ListItem Value="Live5.Xps.Framework.External.ExternalService">External</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search&Save" />&nbsp;
    <div style="width: 552px; height: 111px">
        &nbsp; &nbsp;
        <div style="width: 200px; height: 100px; float: left;">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <li><asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="width: 350px; float: left;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Title" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
