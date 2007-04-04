<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="QueryManage.aspx.cs" Inherits="Admin_QueryManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" Text="Apply Label" OnClick="Button2_Click" />
    </div>
    <div><asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:HiddenField ID="HiddenField1" runat="server"/>
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Export" CommandName="Export"/>
        </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
