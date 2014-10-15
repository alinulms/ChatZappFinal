<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomNavigationControl.ascx.cs" Inherits="Website.Presentation.Controls.BottomNavigationControl" %>
<div class="navbar navbar-default navbar-fixed-bottom" role="navigation">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">ChatZapp</a>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="<%# IsNewDiscussionPage %>">
                    <asp:LinkButton runat="server" OnClick="NewDiscussion" Text="<%#Website.Resources.N.NewDiscussion %>" />
                </li>
                <li class="<%#IsMessageBoardPage %>">
                    <asp:LinkButton runat="server" OnClick="ShowAllDiscussion" Text="<%#Website.Resources.L.ListDiscussions %>" />
                </li>
                <li>
                    <asp:LinkButton runat="server" OnClick="ChangeRadius" Text="<%# Website.Resources.C.ChangeRadius %>" />
                </li>
            </ul>
        </div>
    </div>
</div>