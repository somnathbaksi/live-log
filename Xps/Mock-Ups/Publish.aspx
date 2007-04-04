<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true" CodeFile="Publish.aspx.cs" Inherits="Mock_Ups_Publish" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:Label ID="Label2" runat="server" Text="Title:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Description:"></asp:Label>&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Content:"></asp:Label>
    &nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="142px" Width="677px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Publish" />
</asp:Content>

