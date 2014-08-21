<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="MessageBoard.aspx.cs" Inherits="Website.Presentation.MessageBoard" %>

<%@ Register Src="~/Presentation/Controls/MessageBoardControl.ascx" TagPrefix="uc1" TagName="MessageBoardControl" %>
<%@ Register Src="~/Presentation/Controls/BottomNavigationControl.ascx" TagPrefix="uc1" TagName="BottomNavigationControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">
  <div class="container">
    <uc1:MessageBoardControl runat="server" id="MessageBoardControl" />
  </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NavigationPlaceholder">
  <uc1:BottomNavigationControl runat="server" id="BottomNavigationControl" />
</asp:Content>