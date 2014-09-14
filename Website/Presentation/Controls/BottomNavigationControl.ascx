<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomNavigationControl.ascx.cs" Inherits="Website.Presentation.Controls.BottomNavigationControl" %>
<div class="navbar navbar-default navbar-fixed-bottom" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <a class="navbar-brand" href="#">ChatZapp</a>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="<%# IsNewDiscussionPage %>">
                    <asp:LinkButton runat="server" OnClick="NewDiscussion" Text="New discussion" />
                </li>
                <li class="<%#IsMessageBoardPage %>">
                    <asp:LinkButton runat="server" OnClick="ShowAllDiscussion" Text="List Discussions" />
                </li>
                <li>
                    <asp:LinkButton runat="server" OnClick="ChangeRadius" Text="Change radius" />
                </li>
            </ul>
        </div>
    </div>
</div>