<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="Home.aspx.cs" Inherits="Website.Presentation.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">

    <asp:Panel runat="server" CssClass="startupControllers">
        <div class="box-wide login-page-box">
            <div class="column-grid">
                <div class="box-two-thirds">
                    <h1 class="headline-medium white"><%#Website.Resources.Home.WelcomeHeadline %></h1>
                    <p class="welcome-text white"><%#Website.Resources.Home.WelcomeIntro%></p>
                </div>
                <div class="box-third">
                    <div class="panel-box">
                        <div class="caption">
                            <h4 class="headline-small"><%#Website.Resources.Home.WhatIsYourName %></h4>
                            <asp:TextBox runat="server" ID="TxtName" class="global-input" />
                            <h4 class="headline-small"><%#Website.Resources.Home.WhatIsTheScanRadius %></h4>
                            <asp:TextBox runat="server" ID="TxtRadius" TextMode="Number" class="global-input" min="1" Text="10" />
                            <asp:LinkButton runat="server" OnClick="SaveNameAndRadius" Text="<%#Website.Resources.Home.Start %>" class="global-button" role="button"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="panel-box">
                        <div class="caption">
                            <asp:LinkButton ID="btnLogin" runat="server" Text="<%#Website.Resources.Home.FacebookLogin %>" class="global-button fb-login" OnClick="Login" />
                            <h4 class="headline-small"><%#Website.Resources.Home.WhatIsTheScanRadius %></h4>
                            <asp:TextBox runat="server" ID="TxtRadiusFacebook" TextMode="Number" min="1" class="global-input" Text="10" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="HiddenContent" ContentPlaceHolderID="HiddenPlaceholder" runat="server">
    <div>
        <asp:HiddenField runat="server" ID="Latitude" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="Longitude" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="GroupId" ClientIDMode="Static" />
    </div>
</asp:Content>
