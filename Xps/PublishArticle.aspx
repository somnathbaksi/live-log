<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="PublishArticle.aspx.cs" Inherits="PublishArticle"
    Title="Untitled Page" Trace="true" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 475px; height: 28px">
        <asp:Label ID="Label1" runat="server" Text="Title:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="275px"></asp:TextBox>&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>&nbsp;
    </div>
    <div style="width: 100px; height: 100px">
        <asp:Label ID="Label2" runat="server" Text="Summary:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="136px" Width="392px"></asp:TextBox></div>
    <div style="width: 100%; height: 300px">
        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/">
        </FCKeditorV2:FCKeditor>
    </div>
    <div style="width: 354px; height: 100px">
        <asp:Button ID="Button1" runat="server" Text="Publish" OnClick="Button1_Click" /></div>
</asp:Content>
