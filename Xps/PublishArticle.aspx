<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="PublishArticle.aspx.cs" Inherits="PublishArticle"
    Title="Untitled Page" Trace="true" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/" OnDataBinding="FCKeditor1_DataBinding">
    </FCKeditorV2:FCKeditor>
</asp:Content>
