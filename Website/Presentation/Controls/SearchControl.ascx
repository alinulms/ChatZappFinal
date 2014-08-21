<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchControl.ascx.cs" Inherits="Website.Presentation.Controls.SearchControl" %>
<div>
    <asp:TextBox ID="searchTxt" runat="server"/>
    <asp:Button runat="server" ID="btnSearch" OnClick="SearchDiscussion" Text="Search"/>
</div>