﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomNavigationControl.ascx.cs" Inherits="Website.Presentation.Controls.BottomNavigationControl" %>
<%@ Import Namespace="Website.Resources" %>
<div class="navbar navbar-default navbar-fixed-bottom" role="navigation">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">ChatZapp</a>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="<%# IsNewDiscussionPage %>">
                    <asp:LinkButton runat="server" OnClick="NewDiscussion" Text="<%#Resources.N.NewDiscussion %>" />
                </li>
                <li class="<%#IsMessageBoardPage %>">
                    <asp:LinkButton runat="server" OnClick="ShowAllDiscussion" Text="<%#Resources.L.ListDiscussions %>" />
                </li>
                <li>
                    <asp:LinkButton runat="server" OnClick="ChangeRadius" Text="<%# Resources.C.ChangeRadius %>" />
                </li>
            </ul>
        </div>
    </div>
</div>