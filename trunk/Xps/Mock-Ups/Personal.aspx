<%@ Page Language="C#" MasterPageFile="~/MasterPages/XpsDefault.master" AutoEventWireup="true"
    CodeFile="Personal.aspx.cs" Inherits="Mock_Ups_Personal" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 20%; height: auto; float: left;">
        <ul>
            <li><span style="cursor: pointer;" onclick="LoadFeed('eb1ccc3e-ad7c-4a87-a5bb-056409e8d0f4')">
                CodeProject</span></li>
            <li><span style="cursor: pointer;" onclick="LoadFeed('61704ab7-d83c-4b87-9277-0b4d07fe7eef')">
                Mofile</span></li>
        </ul>
    </div>
    <div style="float: left; width: 80%; height: auto;">
        <iframe  id="feed" src="External.aspx?q=eb1ccc3e-ad7c-4a87-a5bb-056409e8d0f4" width="600px" height="800px">ddd</iframe>
    </div>
</asp:Content>
