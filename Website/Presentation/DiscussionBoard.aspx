<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="DiscussionBoard.aspx.cs" Inherits="Website.Presentation.DiscussionBoard" %>

<%@ Register Src="~/Presentation/Controls/DiscussionControl.ascx" TagPrefix="uc1" TagName="DiscussionControl" %>
<%@ Register Src="~/Presentation/Controls/BottomNavigationControl.ascx" TagPrefix="uc1" TagName="BottomNavigationControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">
  <uc1:DiscussionControl runat="server" ID="DiscussionControl" />
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NavigationPlaceholder">
  <uc1:BottomNavigationControl runat="server" ID="BottomNavigationControl" />
</asp:Content>